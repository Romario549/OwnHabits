import React, { createContext, useContext, useEffect, useState, useCallback } from 'react';
import { authApi } from '../../api/auth';
import type { User } from '../../types/User';
import Cookies from 'js-cookie';

interface UserContextType {
  user: User | null;
  loading: boolean;
  error: string | null;
  refreshUser: () => Promise<void>;
  logout: () => Promise<void>;
}

const UserContext = createContext<UserContextType | undefined>(undefined);

export const useUser = () => {
  const context = useContext(UserContext);
  if (!context) {
    throw new Error('useUser must be used within a UserProvider');
  }
  return context;
};

export const UserProvider: React.FC<{ children: React.ReactNode }> = ({ children }) => {
  const [user, setUser] = useState<User | null>(null);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);

  const refreshUser = useCallback(async () => {
    try {
      setLoading(true);
      setError(null);
      
      // 1. Сначала пробуем получить пользователя из localStorage
      const storedUser = authApi.getStoredUser();
      if (storedUser) {
        console.log('User loaded from localStorage:', storedUser);
        setUser(storedUser);
        setLoading(false);
        return;
      }
      
      // 2. Если нет в localStorage, пробуем по email из куки
      const email = Cookies.get('userEmail');
      console.log('Email from cookie:', email);
      
      if (email) {
        try {
          const userByEmail = await authApi.getUserByEmail(email);
          console.log('User loaded by email:', userByEmail);
          setUser(userByEmail);
          localStorage.setItem('user', JSON.stringify(userByEmail));
        } catch (err) {
          console.error('Failed to load user by email:', err);
          Cookies.remove('userEmail', { path: '/' });
          setUser(null);
        }
      } else {
        setUser(null);
      }
    } catch (err: any) {
      setError(err.response?.data?.message || 'Failed to load user');
      console.error('Error loading user:', err);
      setUser(null);
    } finally {
      setLoading(false);
    }
  }, []);

  const logout = async () => {
    try {
      await authApi.logout();
    } catch (error) {
      console.error('Logout error:', error);
    } finally {
      Cookies.remove('userEmail', { path: '/' });
      localStorage.removeItem('user');
      setUser(null);
    }
  };

  useEffect(() => {
    refreshUser();
  }, [refreshUser]);

  return (
    <UserContext.Provider value={{ user, loading, error, refreshUser, logout }}>
      {children}
    </UserContext.Provider>
  );
};
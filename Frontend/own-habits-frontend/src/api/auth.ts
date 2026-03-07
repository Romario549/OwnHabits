import axios from 'axios';
import type { RegisterData } from '../types/RegisterData';
import Cookies from "js-cookie";
import type { User } from '../types/User';

const API_URL = 'https://localhost:7172/api'; 

const api = axios.create({
  baseURL: API_URL,
  withCredentials: true,
});

export const authApi = {
  login: async (email: string, password: string, rememberMe: boolean = false) => {
    try {
      const response = await api.post('/users/login', { 
        email, 
        password,
        rememberMe 
      });

      console.log('Login response:', response.data);
      
      if (response.data) {
        authApi.setUserEmailCookie(email);
        
        if (response.data.user) {
          localStorage.setItem('user', JSON.stringify(response.data.user));
        }
      }
      
      return response.data;
    } catch (error) {
      console.error('Login error:', error);
      throw error;
    }
  },
  
  register: async (registerData: RegisterData) => {
    const response = await api.post('/users/registration', registerData);
    return response.data;
  },
  
  logout: async () => {
    try {
      const response = await api.post('/users/logout');
      return response.data;
    } finally {
      Cookies.remove('userEmail', { path: '/' });
      localStorage.removeItem('user');
    }
  },

  googleLogin: () => {
    window.location.href = 'https://localhost:7172/api/ExternalAuth/google-login';
  },
  
  setUserEmailCookie: (email: string) => {
    Cookies.set('userEmail', email, { 
      expires: 7,
      secure: false,
      sameSite: 'lax',
      path: '/'
    });
  },
  
  getUserByEmail: async (email: string): Promise<User> => {
    const response = await api.get(`/users/info/${encodeURIComponent(email)}`);
    return response.data;
  },

  // Получить пользователя из localStorage
  getStoredUser: (): User | null => {
    const userStr = localStorage.getItem('user');
    if (userStr) {
      try {
        return JSON.parse(userStr);
      } catch {
        return null;
      }
    }
    return null;
  },

  hasStoredUser: (): boolean => {
    return !!Cookies.get('userEmail') || !!localStorage.getItem('user');
  }
};
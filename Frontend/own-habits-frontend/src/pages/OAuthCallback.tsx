// src/pages/OAuthCallback.tsx
import { useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import { authApi } from '../api/auth';
import { useUser } from './user/UserContext';
import { Box, CircularProgress, Typography } from '@mui/material';

const OAuthCallback = () => {
  const navigate = useNavigate();
  const { refreshUser } = useUser();

  useEffect(() => {
    const handleCallback = async () => {
      try {
        const params = new URLSearchParams(window.location.search);
        const userJson = params.get('user');
        const email = params.get('email');
        
        console.log('OAuth callback - user from URL:', userJson);
        console.log('OAuth callback - email from URL:', email);
        if (userJson) {
          const userData = JSON.parse(decodeURIComponent(userJson));
          
          // Нормализуем поля (делаем с маленькой буквы)
          const normalizedUser = {
            id: userData.Id || userData.id,
            userName: userData.UserName || userData.userName,
            email: userData.Email || userData.email,
            completedGoals: userData.CompletedGoals || userData.completedGoals || 0,
            grade: userData.Grade || userData.grade || 'Newbie'
          };
          
          console.log('Normalized user data:', normalizedUser);
          
          if (normalizedUser.email) {
            authApi.setUserEmailCookie(normalizedUser.email);
          }
          
          localStorage.setItem('user', JSON.stringify(normalizedUser));
        } else if (email) {
          // Если только email, сохраняем его
          authApi.setUserEmailCookie(email);
        }
        
        // Обновляем пользователя в контексте - ЭТО ВАЖНО!
        await refreshUser();
        
        // Редиректим на главную
        navigate('/tasks', { replace: true });
      } catch (error) {
        console.error('OAuth callback error:', error);
        navigate('/login?error=Ошибка входа через Google');
      }
    };

    handleCallback();
  }, [navigate, refreshUser]);

  return (
    <Box sx={{ display: 'flex', flexDirection: 'column', alignItems: 'center', justifyContent: 'center', height: '100vh' }}>
      <CircularProgress size={60} />
      <Typography sx={{ mt: 2 }}>Завершение входа через Google...</Typography>
    </Box>
  );
};

export default OAuthCallback;
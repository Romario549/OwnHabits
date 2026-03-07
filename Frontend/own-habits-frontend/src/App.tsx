import './App.css';
import { Routes, Route, Navigate } from 'react-router-dom';
import { GoogleOAuthProvider } from '@react-oauth/google';
import { ThemeProvider, createTheme } from '@mui/material/styles';
import CssBaseline from '@mui/material/CssBaseline';
import { UserProvider } from './pages/user/UserContext';
import ProtectedRoute from './components/ProtectedRoute';
import Login from './pages/user/Login';
import Register from './pages/user/Registration';
import MainLayout from './pages/layout/MainLayout';

// Страницы
import GoalsPage from './pages/GoalsPage';
import ProfilePage from './pages/ProfilePage';
import CalendarPage from './pages/CalendarPage';
import AchievementsPage from './pages/AchievementsPage';
import StatisticsPage from './pages/StatisticsPage';
import NotificationsPage from './pages/NotificationsPage';
import SettingsPage from './pages/SettingsPage';
import OAuthCallback from './pages/OAuthCallback';

const theme = createTheme({
  palette: {
    primary: {
      main: '#6366f1',
      light: '#8183f4',
      dark: '#4547b0',
    },
    secondary: {
      main: '#ec4899',
    },
    background: {
      default: '#f9fafc',
      paper: '#ffffff',
    },
  },
  shape: {
    borderRadius: 12,
  },
  typography: {
    fontFamily: '"Inter", "Roboto", "Helvetica", "Arial", sans-serif',
  },
});

const GOOGLE_CLIENT_ID = import.meta.env.VITE_GOOGLE_CLIENT_ID;

function App() {
  return (
    <GoogleOAuthProvider clientId={GOOGLE_CLIENT_ID}>
      <ThemeProvider theme={theme}>
        <CssBaseline />
        <UserProvider> {/* UserProvider должен быть здесь */}
          <Routes>
            {/* Публичные маршруты */}
            <Route path="/login" element={<Login />} />
            <Route path="/register" element={<Register />} />
            <Route path="/oauth-callback" element={<OAuthCallback />} />

            
            {/* Защищенные маршруты с Layout */}
            <Route path="/" element={
              <ProtectedRoute>
                <MainLayout />
              </ProtectedRoute>
            }>
              <Route index element={<Navigate to="/goals" replace />} />
              <Route path="goals" element={<GoalsPage />} />
              <Route path="profile" element={<ProfilePage />} />
              <Route path="calendar" element={<CalendarPage />} />
              <Route path="achievements" element={<AchievementsPage />} />
              <Route path="statistics" element={<StatisticsPage />} />
              <Route path="notifications" element={<NotificationsPage />} />
              <Route path="settings" element={<SettingsPage />} />
            </Route>
            
            {/* 404 */}
            <Route path="*" element={<Navigate to="/goals" replace />} />
          </Routes>
        </UserProvider>
      </ThemeProvider>
    </GoogleOAuthProvider>
  );
}

export default App;
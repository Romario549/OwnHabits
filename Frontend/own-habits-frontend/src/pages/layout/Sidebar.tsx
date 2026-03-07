import React, { type JSX } from 'react';
import {
  Drawer,
  Box,
  List,
  ListItem,
  ListItemButton,
  ListItemIcon,
  ListItemText,
  Typography,
  Avatar,
  Badge,
  Chip,
  Tooltip,
  IconButton,
  useTheme,
  alpha,
  useMediaQuery,
  LinearProgress,
  Skeleton,
  Fade,
  Zoom
} from '@mui/material';
import {
  Task as TaskIcon,
  Person as PersonIcon,
  CalendarMonth as CalendarIcon,
  EmojiEvents as AchievementIcon,
  BarChart as BarChartIcon,
  Settings as SettingsIcon,
  Logout as LogoutIcon,
  Notifications as NotificationsIcon,
  ChevronLeft as ChevronLeftIcon,
  ChevronRight as ChevronRightIcon,
  School as SchoolIcon,
  TrendingUp as TrendingUpIcon,
  Star as StarIcon,
  EmojiEvents as EmojiIcon
} from '@mui/icons-material';
import { useNavigate, useLocation } from 'react-router-dom';
import { useUser } from '../user/UserContext';

const drawerWidth = 260;
const collapsedWidth = 80;

interface SidebarProps {
  open: boolean;
  onToggle: () => void;
}

// Конфигурация для градаций пользователя
const gradeConfig: Record<string, { color: string; icon: JSX.Element }> = {
  'Newbie': { color: '#9e9e9e', icon: <SchoolIcon /> },
  'Beginner': { color: '#4caf50', icon: <TrendingUpIcon /> },
  'Intermediate': { color: '#2196f3', icon: <StarIcon /> },
  'Advanced': { color: '#ff9800', icon: <EmojiIcon /> },
  'Expert': { color: '#f44336', icon: <AchievementIcon /> },
  'Master': { color: '#9c27b0', icon: <SchoolIcon /> }
};

const Sidebar: React.FC<SidebarProps> = ({ open, onToggle }) => {
  const theme = useTheme();
  const navigate = useNavigate();
  const location = useLocation();
  const isMobile = useMediaQuery(theme.breakpoints.down('sm'));
  const { user, logout, loading } = useUser();

  const menuItems = [
    {
      id: 'tasks',
      text: 'Задачи',
      icon: <TaskIcon />,
      path: '/tasks',
      badge: 3
    },
    {
      id: 'profile',
      text: 'Профиль',
      icon: <PersonIcon />,
      path: '/profile'
    },
    {
      id: 'calendar',
      text: 'Календарь',
      icon: <CalendarIcon />,
      path: '/calendar'
    },
    {
      id: 'achievements',
      text: 'Достижения',
      icon: <AchievementIcon />,
      path: '/achievements',
      badge: 2
    },
    {
      id: 'statistics',
      text: 'Статистика',
      icon: <BarChartIcon />,
      path: '/statistics'
    }
  ];

  const handleNavigation = (path: string) => {
    navigate(path);
    if (isMobile) {
      onToggle();
    }
  };

  const handleLogout = async () => {
    await logout();
    navigate('/login');
  };

  const isActive = (path: string) => {
    return location.pathname === path;
  };

  // Показываем скелетон во время загрузки
  if (loading) {
    return (
      <Drawer
        variant={isMobile ? "temporary" : "permanent"}
        open={isMobile ? open : true}
        onClose={onToggle}
        sx={{
          width: open ? drawerWidth : collapsedWidth,
          flexShrink: 0,
          transition: theme.transitions.create('width', {
            easing: theme.transitions.easing.easeInOut,
            duration: theme.transitions.duration.complex,
          }),
          '& .MuiDrawer-paper': {
            width: open ? drawerWidth : collapsedWidth,
            boxSizing: 'border-box',
            transition: theme.transitions.create('width', {
              easing: theme.transitions.easing.easeInOut,
              duration: theme.transitions.duration.complex,
            }),
            overflowX: 'hidden',
          }
        }}
      >
        <Box sx={{ p: 2 }}>
          <Skeleton variant="circular" width={40} height={40} />
          <Skeleton variant="text" sx={{ mt: 1 }} />
          <Skeleton variant="text" width="60%" />
        </Box>
      </Drawer>
    );
  }

  // Если пользователь не загружен, не показываем сайдбар
  if (!user) {
    return null;
  }

  const grade = gradeConfig[user.grade] || gradeConfig['Newbie'];
  const userInitial = user.userName?.charAt(0).toUpperCase() || 'U';

  return (
    <Drawer
      variant={isMobile ? "temporary" : "permanent"}
      open={isMobile ? open : true}
      onClose={onToggle}
      sx={{
        width: open ? drawerWidth : collapsedWidth,
        flexShrink: 0,
        transition: theme.transitions.create('width', {
          easing: theme.transitions.easing.easeInOut,
          duration: theme.transitions.duration.complex,
        }),
        '& .MuiDrawer-paper': {
          width: open ? drawerWidth : collapsedWidth,
          boxSizing: 'border-box',
          backgroundColor: theme.palette.background.default,
          borderRight: `1px solid ${alpha(theme.palette.divider, 0.1)}`,
          transition: theme.transitions.create('width', {
            easing: theme.transitions.easing.easeInOut,
            duration: theme.transitions.duration.complex,
          }),
          overflowX: 'hidden',
          display: 'flex',
          flexDirection: 'column'
        },
      }}
    >
      {/* Заголовок с логотипом */}
      <Box
        sx={{
          display: 'flex',
          alignItems: 'center',
          justifyContent: open ? 'space-between' : 'center',
          padding: theme.spacing(2, open ? 2 : 1),
          borderBottom: `1px solid ${alpha(theme.palette.divider, 0.1)}`,
          minHeight: 64
        }}
      >
        {open ? (
          <Box sx={{ display: 'flex', alignItems: 'center', gap: 1, width: '100%' }}>
            <Zoom in={open} timeout={400}>
              <Box
                component="img"
                src="/logo.svg"
                alt="OwnHabits"
                sx={{ width: 32, height: 32 }}
              />
            </Zoom>
            <Fade in={open} timeout={500}>
              <Typography 
                variant="h6" 
                sx={{ 
                  fontWeight: 700, 
                  color: theme.palette.primary.main,
                  whiteSpace: 'nowrap',
                  flex: 1
                }}
              >
                OwnHabits
              </Typography>
            </Fade>
            <Tooltip title="Свернуть меню">
              <IconButton 
                onClick={onToggle} 
                size="small"
                sx={{
                  transition: theme.transitions.create('transform', {
                    easing: theme.transitions.easing.easeInOut,
                    duration: theme.transitions.duration.shorter,
                  }),
                  '&:hover': {
                    transform: 'rotate(180deg)',
                  }
                }}
              >
                <ChevronLeftIcon />
              </IconButton>
            </Tooltip>
          </Box>
        ) : (
          <Tooltip title="Развернуть меню">
            <IconButton 
              onClick={onToggle} 
              size="small"
              sx={{
                transition: theme.transitions.create('transform', {
                  easing: theme.transitions.easing.easeInOut,
                  duration: theme.transitions.duration.shorter,
                }),
                '&:hover': {
                  transform: 'rotate(180deg)',
                }
              }}
            >
              <ChevronRightIcon />
            </IconButton>
          </Tooltip>
        )}
      </Box>

      {/* Краткая информация о пользователе */}
      <Box 
        sx={{ 
          p: open ? 2 : 1, 
          borderBottom: `1px solid ${alpha(theme.palette.divider, 0.1)}`,
          display: 'flex',
          flexDirection: 'column',
          alignItems: open ? 'stretch' : 'center'
        }}
      >
        <Box
          sx={{
            display: 'flex',
            alignItems: 'center',
            gap: open ? 2 : 1,
            cursor: 'pointer',
            '&:hover': { 
              opacity: 0.8,
              '& .MuiAvatar-root': {
                transform: 'scale(1.05)',
              }
            }
          }}
          onClick={() => handleNavigation('/profile')}
        >
          <Badge
            overlap="circular"
            anchorOrigin={{ vertical: 'bottom', horizontal: 'right' }}
            badgeContent={
              <Zoom in={true} style={{ transitionDelay: '100ms' }}>
                <Box
                  sx={{
                    width: 12,
                    height: 12,
                    borderRadius: '50%',
                    bgcolor: theme.palette.success.main,
                    border: `2px solid ${theme.palette.background.paper}`
                  }}
                />
              </Zoom>
            }
          >
            <Avatar
              sx={{
                width: open ? 48 : 40,
                height: open ? 48 : 40,
                bgcolor: grade.color,
                fontSize: open ? 20 : 16,
                fontWeight: 'bold',
                transition: theme.transitions.create(['width', 'height', 'font-size', 'transform'], {
                  easing: theme.transitions.easing.easeInOut,
                  duration: theme.transitions.duration.shorter,
                }),
              }}
            >
              {userInitial}
            </Avatar>
          </Badge>
          
          {open && (
            <Fade in={open} timeout={400}>
              <Box sx={{ flex: 1, minWidth: 0 }}>
                <Typography 
                  variant="subtitle2" 
                  sx={{ 
                    fontWeight: 600, 
                    noWrap: "auto"
                  }}
                >
                  {user.userName}
                </Typography>
                <Typography 
                  variant="caption" 
                  color="textSecondary" 
                  sx={{ 
                    noWrap: "auto"
                  }}
                >
                  {user.email}
                </Typography>
              </Box>
            </Fade>
          )}
        </Box>

        {/* Прогресс-бар с опытом */}
        {open && (
          <Fade in={open} timeout={500}>
            <Box sx={{ mt: 2 }}>
              <Box sx={{ display: 'flex', justifyContent: 'space-between', mb: 0.5 }}>
                <Typography variant="caption" color="textSecondary">
                  Уровень
                </Typography>
                <Typography variant="caption" fontWeight={500}>
                  {user.completedGoals * 10} XP
                </Typography>
              </Box>
              <LinearProgress
                variant="determinate"
                value={Math.min((user.completedGoals % 10) * 10, 100)}
                sx={{ 
                  height: 4, 
                  borderRadius: 2,
                  bgcolor: alpha(grade.color, 0.1),
                  '& .MuiLinearProgress-bar': {
                    bgcolor: grade.color,
                    transition: theme.transitions.create('width', {
                      easing: theme.transitions.easing.easeInOut,
                      duration: theme.transitions.duration.complex,
                    }),
                  }
                }}
              />
            </Box>
          </Fade>
        )}
      </Box>

      {/* Основное меню */}
      <List sx={{ px: 1, py: 2, flex: 1 }}>
        {menuItems.map((item) => (
          <ListItem key={item.id} disablePadding sx={{ mb: 0.5 }}>
            <Tooltip title={!open ? item.text : ''} placement="right" arrow>
              <ListItemButton
                onClick={() => handleNavigation(item.path)}
                selected={isActive(item.path)}
                sx={{
                  borderRadius: 2,
                  py: 1.5,
                  justifyContent: open ? 'initial' : 'center',
                  '&.Mui-selected': {
                    backgroundColor: alpha(theme.palette.primary.main, 0.1),
                    '&:hover': {
                      backgroundColor: alpha(theme.palette.primary.main, 0.15),
                    },
                    '& .MuiListItemIcon-root': {
                      color: theme.palette.primary.main,
                    },
                    '& .MuiListItemText-primary': {
                      color: theme.palette.primary.main,
                      fontWeight: 600,
                    },
                  },
                  '&:hover': {
                    backgroundColor: alpha(theme.palette.primary.main, 0.05),
                    transform: 'translateX(4px)',
                  },
                }}
              >
                <ListItemIcon 
                  sx={{ 
                    minWidth: open ? 40 : 'auto',
                    mr: open ? 0 : 'auto',
                    color: isActive(item.path) ? theme.palette.primary.main : theme.palette.text.secondary
                  }}
                >
                  {item.icon}
                </ListItemIcon>
                {open && (
                  <>
                    <ListItemText 
                      primary={item.text}
                      primaryTypographyProps={{
                        fontSize: '0.95rem',
                        fontWeight: isActive(item.path) ? 600 : 500,
                      }}
                    />
                    {item.badge && (
                      <Zoom in={open} timeout={300}>
                        <Chip
                          label={item.badge}
                          size="small"
                          color="primary"
                          sx={{
                            height: 20,
                            minWidth: 20,
                            '& .MuiChip-label': {
                              px: 0.5,
                              fontSize: '0.7rem',
                              fontWeight: 600
                            }
                          }}
                        />
                      </Zoom>
                    )}
                  </>
                )}
                {!open && item.badge && (
                  <Badge
                    badgeContent={item.badge}
                    color="primary"
                    sx={{
                      position: 'absolute',
                      top: 8,
                      right: 8,
                      '& .MuiBadge-badge': {
                        fontSize: '0.6rem',
                        height: 16,
                        minWidth: 16,
                        animation: 'pulse 2s infinite',
                        '@keyframes pulse': {
                          '0%': {
                            transform: 'scale(1)',
                          },
                          '50%': {
                            transform: 'scale(1.1)',
                          },
                          '100%': {
                            transform: 'scale(1)',
                          },
                        },
                      }
                    }}
                  />
                )}
              </ListItemButton>
            </Tooltip>
          </ListItem>
        ))}
      </List>

      {/* Нижняя часть с дополнительными кнопками */}
      <Box sx={{ p: open ? 2 : 1, borderTop: `1px solid ${alpha(theme.palette.divider, 0.1)}` }}>
        <List disablePadding>
          <ListItem disablePadding sx={{ mb: 0.5 }}>
            <Tooltip title={!open ? 'Уведомления' : ''} placement="right" arrow>
              <ListItemButton
                onClick={() => handleNavigation('/notifications')}
                sx={{ 
                  borderRadius: 2, 
                  py: 1.5,
                  justifyContent: open ? 'initial' : 'center',
                  '&:hover': {
                    transform: 'translateX(4px)',
                  }
                }}
              >
                <ListItemIcon sx={{ 
                  minWidth: open ? 40 : 'auto', 
                  mr: open ? 0 : 'auto'
                }}>
                  <Badge badgeContent={5} color="error">
                    <NotificationsIcon />
                  </Badge>
                </ListItemIcon>
                {open && (
                  <Fade in={open} timeout={300}>
                    <ListItemText primary="Уведомления" />
                  </Fade>
                )}
              </ListItemButton>
            </Tooltip>
          </ListItem>
          
          <ListItem disablePadding sx={{ mb: 0.5 }}>
            <Tooltip title={!open ? 'Настройки' : ''} placement="right" arrow>
              <ListItemButton
                onClick={() => handleNavigation('/settings')}
                sx={{ 
                  borderRadius: 2, 
                  py: 1.5,
                  justifyContent: open ? 'initial' : 'center',
                  '&:hover': {
                    transform: 'translateX(4px)',
                  }
                }}
              >
                <ListItemIcon sx={{ 
                  minWidth: open ? 40 : 'auto', 
                  mr: open ? 0 : 'auto'
                }}>
                  <SettingsIcon />
                </ListItemIcon>
                {open && (
                  <Fade in={open} timeout={300}>
                    <ListItemText primary="Настройки" />
                  </Fade>
                )}
              </ListItemButton>
            </Tooltip>
          </ListItem>
          
          <ListItem disablePadding>
            <Tooltip title={!open ? 'Выйти' : ''} placement="right" arrow>
              <ListItemButton
                onClick={handleLogout}
                sx={{ 
                  borderRadius: 2, 
                  py: 1.5,
                  justifyContent: open ? 'initial' : 'center',
                  '&:hover': {
                    transform: 'translateX(4px)',
                    backgroundColor: alpha(theme.palette.error.main, 0.05),
                  }
                }}
              >
                <ListItemIcon sx={{ 
                  minWidth: open ? 40 : 'auto', 
                  mr: open ? 0 : 'auto',
                  color: theme.palette.error.main
                }}>
                  <LogoutIcon />
                </ListItemIcon>
                {open && (
                  <Fade in={open} timeout={300}>
                    <ListItemText 
                      primary="Выйти"
                      primaryTypographyProps={{ color: theme.palette.error.main }}
                    />
                  </Fade>
                )}
              </ListItemButton>
            </Tooltip>
          </ListItem>
        </List>
      </Box>
    </Drawer>
  );
};

export default Sidebar;
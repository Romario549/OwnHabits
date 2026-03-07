import React, { type JSX } from 'react';
import {
  Paper,
  Box,
  Avatar,
  Typography,
  Chip,
  IconButton,
  Grid,
  useTheme
} from '@mui/material';
import {
  Email as EmailIcon,
  Star as StarIcon,
  CheckCircle as CheckCircleIcon,
  EmojiEvents as AchievementIcon,
  School as SchoolIcon,
  TrendingUp as TrendingUpIcon,
  Edit as EditIcon,
  EmojiEmotions as EmojiEventsIcon
} from '@mui/icons-material';
import type { User } from '../../types/User';

interface ProfileHeaderProps {
  user: User;
  totalExp: number;
}

const gradeConfig: Record<string, { color: string; label: string; icon: JSX.Element }> = {
  'Newbie': { color: '#9e9e9e', label: 'Новичок', icon: <SchoolIcon /> },
  'Beginner': { color: '#4caf50', label: 'Начинающий', icon: <TrendingUpIcon /> },
  'Intermediate': { color: '#2196f3', label: 'Средний', icon: <StarIcon /> },
  'Advanced': { color: '#ff9800', label: 'Продвинутый', icon: <EmojiEventsIcon /> },
  'Expert': { color: '#f44336', label: 'Эксперт', icon: <AchievementIcon /> },
  'Master': { color: '#9c27b0', label: 'Мастер', icon: <SchoolIcon /> }
};

const ProfileHeader: React.FC<ProfileHeaderProps> = ({ user, totalExp }) => {
  const theme = useTheme();
  const grade = gradeConfig[user.grade] || gradeConfig['Newbie'];

  console.log('ProfileHeader received user:', user);

  return (
    <Paper 
      sx={{ 
        p: 4, 
        mb: 3,
        background: `linear-gradient(135deg, ${theme.palette.primary.main} 0%, ${theme.palette.secondary.main} 100%)`,
        color: 'white',
        borderRadius: 3
      }}
    >
      <Grid container spacing={3} alignItems="center">
        <Grid size={{ xs: 12, md: 'auto' }}>
          <Avatar
            sx={{
              width: 120,
              height: 120,
              bgcolor: 'white',
              color: theme.palette.primary.main,
              fontSize: 48,
              fontWeight: 'bold',
              border: '4px solid white',
              boxShadow: theme.shadows[4],
              mx: { xs: 'auto', md: 0 }
            }}
          >
            {user.userName?.charAt(0).toUpperCase()}
          </Avatar>
        </Grid>
        
        <Grid size={{ xs: 12, md: 'auto' }}>
          <Box sx={{ textAlign: { xs: 'center', md: 'left' } }}>
            <Box sx={{ 
              display: 'flex', 
              alignItems: 'center', 
              gap: 1, 
              mb: 2, 
              justifyContent: { xs: 'center', md: 'flex-start' } 
            }}>
              <Typography variant="h4" fontWeight="bold">
                {user.userName}
              </Typography>
              <IconButton size="small" sx={{ color: 'white', bgcolor: 'rgba(255,255,255,0.1)' }}>
                <EditIcon />
              </IconButton>
            </Box>
            
            <Grid container spacing={2}>
              <Grid size={{ xs: 12, sm: 6, md: 3 }}>
                <Chip
                  icon={<EmailIcon />}
                  label={user.email}
                  sx={{ 
                    bgcolor: 'rgba(255,255,255,0.15)', 
                    color: 'white',
                    '& .MuiChip-icon': { color: 'white' },
                    height: 32,
                    width: '100%'
                  }}
                />
              </Grid>
              
              <Grid size={{ xs: 12, sm: 6, md: 3 }}>
                <Chip
                  icon={grade.icon}
                  label={grade.label}
                  sx={{ 
                    bgcolor: grade.color,
                    color: 'white',
                    fontWeight: 'bold',
                    height: 32,
                    width: '100%'
                  }}
                />
              </Grid>
              
              <Grid size={{ xs: 12, sm: 6, md: 3 }}>
                <Chip
                  icon={<CheckCircleIcon />}
                  label={`${user.completedGoals} задач`}
                  sx={{ 
                    bgcolor: 'rgba(255,255,255,0.15)', 
                    color: 'white',
                    '& .MuiChip-icon': { color: 'white' },
                    height: 32,
                    width: '100%'
                  }}
                />
              </Grid>
              
              <Grid size={{ xs: 12, sm: 6, md: 3 }}>
                <Chip
                  icon={<AchievementIcon />}
                  label={`${totalExp} опыта`}
                  sx={{ 
                    bgcolor: 'rgba(255,255,255,0.15)', 
                    color: 'white',
                    '& .MuiChip-icon': { color: 'white' },
                    height: 32,
                    width: '100%'
                  }}
                />
              </Grid>
            </Grid>
          </Box>
        </Grid>
      </Grid>
    </Paper>
  );
};

export default ProfileHeader;
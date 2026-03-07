import React, { useState } from 'react';
import {
  Container,
  Paper,
  Typography,
  Box,
  Button,
  Skeleton,
  LinearProgress,
  useTheme,
  alpha
} from '@mui/material';
import { Add as AddIcon } from '@mui/icons-material';
import { useUser } from './user/UserContext';
import ProfileHeader from '../components/profile/ProfileHeader';
import ProfileTabs from '../components/profile/ProfileTabs';
import GoalCard from '../components/profile/GoalCard';
import SkillCard from '../components/profile/SkillCard';
import CharacteristicCard from '../components/profile/CharacteristicCard';
import AddGoalDialog, {type  NewGoalData } from '../components/profile/AddGoalDialog';

const ProfilePage: React.FC = () => {
  const theme = useTheme();
  const { user, loading, error, refreshUser } = useUser();
  const [tabValue, setTabValue] = useState(0);
  const [openGoalDialog, setOpenGoalDialog] = useState(false);

  const handleTabChange = (_event: React.SyntheticEvent, newValue: number) => {
    setTabValue(newValue);
  };

  const calculateTotalExperience = (): number => {
    if (!user?.goals) return 0;
    let total = 0;
    user.goals.forEach(ug => {
      if (ug.goal?.status === 'Completed') {
        total += ug.goal.gainedExperience;
      }
    });
    return total;
  };

  const calculateNextGrade = (): { grade: string; needed: number } | null => {
    if (!user) return null;
    
    const gradeConfig: Record<string, { minExp: number; label: string }> = {
      'Newbie': { minExp: 0, label: 'Новичок' },
      'Beginner': { minExp: 100, label: 'Начинающий' },
      'Intermediate': { minExp: 500, label: 'Средний' },
      'Advanced': { minExp: 2000, label: 'Продвинутый' },
      'Expert': { minExp: 5000, label: 'Эксперт' },
      'Master': { minExp: 10000, label: 'Мастер' }
    };
    
    const currentExp = calculateTotalExperience();
    const grades = Object.entries(gradeConfig);
    const currentIndex = grades.findIndex(([key]) => key === user.grade);
    
    if (currentIndex < grades.length - 1) {
      const nextGrade = grades[currentIndex + 1];
      return {
        grade: nextGrade[1].label,
        needed: Math.max(0, nextGrade[1].minExp - currentExp)
      };
    }
    return null;
  };

  const handleAddGoal = (goalData: NewGoalData) => {
    console.log('New goal:', goalData);
    setOpenGoalDialog(false);
  };

  if (loading) {
    return (
      <Container maxWidth="lg">
        <Box sx={{ mt: 4 }}>
          <Skeleton variant="circular" width={120} height={120} sx={{ mx: 'auto', mb: 2 }} />
          <Skeleton variant="text" height={40} sx={{ mb: 1 }} />
          <Skeleton variant="text" height={30} sx={{ mb: 2 }} />
          <Skeleton variant="rectangular" height={60} sx={{ mb: 2 }} />
          <Skeleton variant="rectangular" height={400} />
        </Box>
      </Container>
    );
  }

  if (error || !user) {
    return (
      <Container maxWidth="lg">
        <Paper sx={{ p: 4, textAlign: 'center', mt: 4 }}>
          <Typography color="error" variant="h6">
            {error || 'Пользователь не найден'}
          </Typography>
          <Button variant="contained" sx={{ mt: 2 }} onClick={() => refreshUser()}>
            Попробовать снова
          </Button>
        </Paper>
      </Container>
    );
  }

  const totalExp = calculateTotalExperience();
  const nextGrade = calculateNextGrade();
  const activeGoals = user.goals?.filter(ug => ug.goal?.status === 'InProgress') || [];
  const completedGoals = user.goals?.filter(ug => ug.goal?.status === 'Completed') || [];

  return (
    <Container maxWidth="lg">
      <ProfileHeader user={user} totalExp={totalExp} />

      {nextGrade && (
        <Paper sx={{ p: 2, mb: 3, bgcolor: alpha(theme.palette.info.main, 0.05) }}>
          <Box sx={{ display: 'flex', alignItems: 'center', gap: 2, flexWrap: 'wrap' }}>
            <Typography variant="body2">
              До звания "{nextGrade.grade}" осталось {nextGrade.needed} опыта
            </Typography>
            <LinearProgress
              variant="determinate"
              value={(totalExp / (totalExp + nextGrade.needed)) * 100}
              sx={{ flex: 1, height: 8, borderRadius: 4 }}
            />
          </Box>
        </Paper>
      )}

      <ProfileTabs 
        value={tabValue} 
        onChange={handleTabChange} 
        counts={{
          goals: user.goals?.length || 0,
          skills: user.skills?.length || 0,
          characteristics: user.characteristics?.length || 0
        }}
      />

      {/* Вкладка Цели */}
      {tabValue === 0 && (
        <Box sx={{ py: 3 }}>
          <Box sx={{ display: 'flex', justifyContent: 'space-between', mb: 2, flexWrap: 'wrap', gap: 2 }}>
            <Typography variant="h5" fontWeight="bold">Мои цели</Typography>
            <Button variant="contained" startIcon={<AddIcon />} onClick={() => setOpenGoalDialog(true)}>
              Добавить цель
            </Button>
          </Box>
          
          {activeGoals.length > 0 && (
            <>
              <Typography variant="subtitle1" fontWeight="medium" sx={{ mb: 1 }}>
                В процессе ({activeGoals.length})
              </Typography>
              {activeGoals.map((ug) => <GoalCard key={ug.id} userGoal={ug} />)}
            </>
          )}
          
          {completedGoals.length > 0 && (
            <>
              <Typography variant="subtitle1" fontWeight="medium" sx={{ mt: 3, mb: 1 }}>
                Выполненные ({completedGoals.length})
              </Typography>
              {completedGoals.map((ug) => <GoalCard key={ug.id} userGoal={ug} />)}
            </>
          )}
          
          {user.goals?.length === 0 && (
            <Paper sx={{ p: 4, textAlign: 'center' }}>
              <Typography color="textSecondary" gutterBottom>У вас пока нет целей</Typography>
              <Button variant="outlined" startIcon={<AddIcon />} onClick={() => setOpenGoalDialog(true)} sx={{ mt: 1 }}>
                Создать первую цель
              </Button>
            </Paper>
          )}
        </Box>
      )}

      {/* Вкладка Навыки */}
      {tabValue === 1 && (
        <Box sx={{ py: 3 }}>
          <Box sx={{ display: 'flex', justifyContent: 'space-between', mb: 2, flexWrap: 'wrap', gap: 2 }}>
            <Typography variant="h5" fontWeight="bold">Мои навыки</Typography>
            <Button variant="contained" startIcon={<AddIcon />}>Добавить навык</Button>
          </Box>
          
          {user.skills && user.skills.length > 0 ? (
            user.skills.map((us) => <SkillCard key={us.id} userSkill={us} />)
          ) : (
            <Paper sx={{ p: 4, textAlign: 'center' }}>
              <Typography color="textSecondary" gutterBottom>У вас пока нет навыков</Typography>
              <Button variant="outlined" startIcon={<AddIcon />} sx={{ mt: 1 }}>Добавить навык</Button>
            </Paper>
          )}
        </Box>
      )}

      {/* Вкладка Характеристики */}
      {tabValue === 2 && (
        <Box sx={{ py: 3 }}>
          <Box sx={{ display: 'flex', justifyContent: 'space-between', mb: 2, flexWrap: 'wrap', gap: 2 }}>
            <Typography variant="h5" fontWeight="bold">Мои характеристики</Typography>
            <Button variant="contained" startIcon={<AddIcon />}>Добавить характеристику</Button>
          </Box>
          
          {user.characteristics && user.characteristics.length > 0 ? (
            user.characteristics.map((uc) => <CharacteristicCard key={uc.id} userCharacteristic={uc} />)
          ) : (
            <Paper sx={{ p: 4, textAlign: 'center' }}>
              <Typography color="textSecondary" gutterBottom>У вас пока нет характеристик</Typography>
              <Button variant="outlined" startIcon={<AddIcon />} sx={{ mt: 1 }}>Добавить характеристику</Button>
            </Paper>
          )}
        </Box>
      )}

      <AddGoalDialog 
        open={openGoalDialog} 
        onClose={() => setOpenGoalDialog(false)} 
        onSubmit={handleAddGoal}
      />
    </Container>
  );
};

export default ProfilePage;
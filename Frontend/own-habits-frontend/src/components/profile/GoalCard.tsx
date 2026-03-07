import React, { type JSX } from 'react';
import {
  Card,
  CardContent,
  Box,
  Typography,
  Chip,
  Grid,
  Tooltip,
  useTheme,
  alpha
} from '@mui/material';
import {
  Flag as FlagIcon,
  Schedule as ScheduleIcon,
  PriorityHigh as PriorityIcon,
  EmojiObjects as SkillIcon,
  AccessTime as AccessTimeIcon,
  Repeat as RepeatIcon,
  Delete as DeleteIcon,
  Warning as WarningIcon,
  CheckCircle as CheckCircleIcon,
  TrendingUp as TrendingUpIcon,
  ArrowUpward as ArrowUpwardIcon,
  ArrowDownward as ArrowDownwardIcon,
  Star as StarIcon
} from '@mui/icons-material';
import type { UserToGoals } from '../../types/UserToGoals';
import type { Status, Priority, Difficulty } from '../../types/Goal';

interface GoalCardProps {
  userGoal: UserToGoals;
}

const statusConfig: Record<Status, { color: string; label: string; icon: JSX.Element }> = {
  'InProgress': { color: '#2196f3', label: 'В процессе', icon: <TrendingUpIcon /> },
  'Completed': { color: '#4caf50', label: 'Выполнено', icon: <CheckCircleIcon /> },
  'Failed': { color: '#f44336', label: 'Провалено', icon: <WarningIcon /> },
  'Cancelled': { color: '#9e9e9e', label: 'Отменено', icon: <DeleteIcon /> }
};

const priorityConfig: Record<Priority, { color: string; label: string; icon: JSX.Element }> = {
  'Low': { color: '#4caf50', label: 'Низкий', icon: <ArrowDownwardIcon /> },
  'Normal': { color: '#ff9800', label: 'Средний', icon: <StarIcon /> },
  'High': { color: '#f44336', label: 'Высокий', icon: <ArrowUpwardIcon /> },
  'Urgent': { color: '#9c27b0', label: 'Срочный', icon: <PriorityIcon /> }
};

const difficultyConfig: Record<Difficulty, { color: string; label: string }> = {
  'Easy': { color: '#4caf50', label: 'Легко' },
  'Medium': { color: '#ff9800', label: 'Средне' },
  'Hard': { color: '#f44336', label: 'Сложно' },
  'Extreme': { color: '#9c27b0', label: 'Экстремально' }
};

const GoalCard: React.FC<GoalCardProps> = ({ userGoal }) => {
  const theme = useTheme();
  const goal = userGoal.goal;
  
  if (!goal) return null;
  
  const status = statusConfig[goal.status] || statusConfig['InProgress'];
  const priority = priorityConfig[goal.priority] || priorityConfig['Normal'];
  const difficulty = difficultyConfig[goal.difficulty] || difficultyConfig['Easy'];
  
  const daysLeft = Math.ceil((new Date(goal.deadline).getTime() - new Date().getTime()) / (1000 * 60 * 60 * 24));
  
  return (
    <Card 
      sx={{ 
        mb: 2,
        borderLeft: `4px solid ${status.color}`,
        '&:hover': { boxShadow: theme.shadows[4] }
      }}
    >
      <CardContent>
        <Box sx={{ display: 'flex', justifyContent: 'space-between', alignItems: 'flex-start', mb: 1 }}>
          <Box>
            <Typography variant="h6" gutterBottom>
              {goal.title}
            </Typography>
            {goal.description && (
              <Typography variant="body2" color="textSecondary" paragraph>
                {goal.description}
              </Typography>
            )}
          </Box>
          <Chip
            size="small"
            icon={status.icon}
            label={status.label}
            sx={{ bgcolor: alpha(status.color, 0.1), color: status.color }}
          />
        </Box>
        
        <Grid container spacing={2} sx={{ mb: 2 }}>
          <Grid size={{ xs: 6, sm: 3 }}>
            <Box sx={{ display: 'flex', alignItems: 'center', gap: 0.5 }}>
              <AccessTimeIcon fontSize="small" color="action" />
              <Typography variant="caption">
                {new Date(goal.createdAt).toLocaleDateString()}
              </Typography>
            </Box>
          </Grid>
          
          <Grid size={{ xs: 6, sm: 3 }}>
            <Box sx={{ display: 'flex', alignItems: 'center', gap: 0.5 }}>
              <ScheduleIcon fontSize="small" color="action" />
              <Typography variant="caption" color={daysLeft < 0 ? 'error' : daysLeft < 3 ? 'warning.main' : 'textSecondary'}>
                {daysLeft < 0 ? 'Просрочено' : `${daysLeft} дн.`}
              </Typography>
            </Box>
          </Grid>
          
          <Grid size={{ xs: 6, sm: 3 }}>
            <Box sx={{ display: 'flex', alignItems: 'center', gap: 0.5 }}>
              {priority.icon}
              <Typography variant="caption" sx={{ color: priority.color }}>
                {priority.label}
              </Typography>
            </Box>
          </Grid>
          
          <Grid size={{ xs: 6, sm: 3 }}>
            <Box sx={{ display: 'flex', alignItems: 'center', gap: 0.5 }}>
              <FlagIcon fontSize="small" />
              <Typography variant="caption">
                {goal.gainedExperience} опыта
              </Typography>
            </Box>
          </Grid>
        </Grid>
        
        <Box sx={{ display: 'flex', gap: 1, flexWrap: 'wrap' }}>
          {goal.repeatability && (
            <Chip
              size="small"
              icon={<RepeatIcon />}
              label="Повторяющаяся"
              variant="outlined"
            />
          )}
          
          <Chip
            size="small"
            label={`Сложность: ${difficulty.label}`}
            variant="outlined"
            sx={{ color: difficulty.color, borderColor: difficulty.color }}
          />
        </Box>
        
        {goal.upgradableSkills && goal.upgradableSkills.length > 0 && (
          <Box sx={{ mt: 2 }}>
            <Typography variant="caption" color="textSecondary" gutterBottom display="block">
              Прокачивает навыки:
            </Typography>
            <Box sx={{ display: 'flex', gap: 0.5, flexWrap: 'wrap' }}>
              {goal.upgradableSkills.map((gs) => gs.skill && (
                <Tooltip key={gs.id} title={`Уровень ${gs.skill.level}`}>
                  <Chip
                    size="small"
                    icon={<SkillIcon />}
                    label={gs.skill.title}
                    variant="outlined"
                    sx={{ 
                      borderColor: alpha(theme.palette.primary.main, 0.3),
                      '&:hover': { bgcolor: alpha(theme.palette.primary.main, 0.05) }
                    }}
                  />
                </Tooltip>
              ))}
            </Box>
          </Box>
        )}
      </CardContent>
    </Card>
  );
};

export default GoalCard;
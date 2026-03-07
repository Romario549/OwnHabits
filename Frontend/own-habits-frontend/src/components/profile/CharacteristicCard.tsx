import React from 'react';
import {
  Card,
  CardContent,
  Box,
  Typography,
  Chip,
  LinearProgress,
  Tooltip,
  useTheme,
  alpha
} from '@mui/material';
import {
  Psychology as CharacteristicIcon,
  EmojiObjects as SkillIcon,
  EmojiEvents as AchievementIcon
} from '@mui/icons-material';
import type { UserToCharacteristics } from '../../types/UserToCharacteristics';

interface CharacteristicCardProps {
  userCharacteristic: UserToCharacteristics;
}

const CharacteristicCard: React.FC<CharacteristicCardProps> = ({ userCharacteristic }) => {
  const theme = useTheme();
  const characteristic = userCharacteristic.characteristic;
  
  if (!characteristic) return null;
  
  const expProgress = (characteristic.currentExperience / characteristic.nextLevelExperience) * 100;
  
  return (
    <Card sx={{ mb: 2 }}>
      <CardContent>
        <Box sx={{ display: 'flex', alignItems: 'center', gap: 1, mb: 2 }}>
          <CharacteristicIcon sx={{ color: theme.palette.info.main }} />
          <Typography variant="h6" sx={{ flex: 1 }}>
            {characteristic.title}
          </Typography>
          <Chip
            label={`Ур. ${characteristic.level}`}
            size="small"
            color="secondary"
          />
        </Box>
        
        {characteristic.description && (
          <Typography variant="body2" color="textSecondary" paragraph>
            {characteristic.description}
          </Typography>
        )}
        
        <Box sx={{ mb: 2 }}>
          <Box sx={{ display: 'flex', justifyContent: 'space-between', mb: 0.5 }}>
            <Typography variant="caption" color="textSecondary">
              Прогресс до уровня {characteristic.level + 1}
            </Typography>
            <Typography variant="caption" fontWeight="medium">
              {characteristic.currentExperience}/{characteristic.nextLevelExperience} опыта
            </Typography>
          </Box>
          <LinearProgress
            variant="determinate"
            value={Math.min(expProgress, 100)}
            sx={{ 
              height: 6, 
              borderRadius: 3,
              bgcolor: alpha(theme.palette.info.main, 0.1),
              '& .MuiLinearProgress-bar': {
                bgcolor: theme.palette.info.main
              }
            }}
          />
        </Box>
        
        {characteristic.requiredSkills && characteristic.requiredSkills.length > 0 && (
          <Box>
            <Typography variant="caption" color="textSecondary" gutterBottom display="block">
              Требует навыки:
            </Typography>
            <Box sx={{ display: 'flex', gap: 0.5, flexWrap: 'wrap' }}>
              {characteristic.requiredSkills.map((cs) => cs.skill && (
                <Chip
                  key={cs.id}
                  size="small"
                  icon={<SkillIcon />}
                  label={cs.skill.title}
                  variant="outlined"
                  sx={{ borderColor: alpha(theme.palette.warning.main, 0.3) }}
                />
              ))}
            </Box>
          </Box>
        )}
        
        {characteristic.completedAchievements && characteristic.completedAchievements.length > 0 && (
          <Box sx={{ mt: 2 }}>
            <Typography variant="caption" color="textSecondary" gutterBottom display="block">
              Достижения:
            </Typography>
            <Box sx={{ display: 'flex', gap: 0.5, flexWrap: 'wrap' }}>
              {characteristic.completedAchievements.map((achievement) => (
                <Tooltip key={achievement.id} title={achievement.conditionToGet}>
                  <Chip
                    size="small"
                    icon={<AchievementIcon />}
                    label={achievement.title}
                    color="success"
                    variant="outlined"
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

export default CharacteristicCard;
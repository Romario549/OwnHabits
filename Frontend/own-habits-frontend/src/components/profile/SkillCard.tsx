import React from 'react';
import {
  Card,
  CardContent,
  Box,
  Typography,
  Chip,
  LinearProgress,
  useTheme,
  alpha
} from '@mui/material';
import {
  EmojiObjects as SkillIcon,
  Psychology as CharacteristicIcon
} from '@mui/icons-material';
import type { UserToSkills } from '../../types/UserToSkills';

interface SkillCardProps {
  userSkill: UserToSkills;
}

const SkillCard: React.FC<SkillCardProps> = ({ userSkill }) => {
  const theme = useTheme();
  const skill = userSkill.skill;
  
  if (!skill) return null;
  
  const expProgress = (skill.currentExperience / skill.nextLevelExperience) * 100;
  
  return (
    <Card sx={{ mb: 2 }}>
      <CardContent>
        <Box sx={{ display: 'flex', alignItems: 'center', gap: 1, mb: 2 }}>
          <SkillIcon sx={{ color: theme.palette.warning.main }} />
          <Typography variant="h6" sx={{ flex: 1 }}>
            {skill.title}
          </Typography>
          <Chip
            label={`Ур. ${skill.level}`}
            size="small"
            color="primary"
          />
        </Box>
        
        {skill.description && (
          <Typography variant="body2" color="textSecondary" paragraph>
            {skill.description}
          </Typography>
        )}
        
        <Box sx={{ mb: 2 }}>
          <Box sx={{ display: 'flex', justifyContent: 'space-between', mb: 0.5 }}>
            <Typography variant="caption" color="textSecondary">
              Прогресс до уровня {skill.level + 1}
            </Typography>
            <Typography variant="caption" fontWeight="medium">
              {skill.currentExperience}/{skill.nextLevelExperience} опыта
            </Typography>
          </Box>
          <LinearProgress
            variant="determinate"
            value={Math.min(expProgress, 100)}
            sx={{ 
              height: 6, 
              borderRadius: 3,
              bgcolor: alpha(theme.palette.warning.main, 0.1),
              '& .MuiLinearProgress-bar': {
                bgcolor: theme.palette.warning.main
              }
            }}
          />
        </Box>
        
        {skill.upgradableCharacteristics && skill.upgradableCharacteristics.length > 0 && (
          <Box>
            <Typography variant="caption" color="textSecondary" gutterBottom display="block">
              Влияет на характеристики:
            </Typography>
            <Box sx={{ display: 'flex', gap: 0.5, flexWrap: 'wrap' }}>
              {skill.upgradableCharacteristics.map((sc) => sc.characteristic && (
                <Chip
                  key={sc.id}
                  size="small"
                  icon={<CharacteristicIcon />}
                  label={sc.characteristic.title}
                  variant="outlined"
                  sx={{ borderColor: alpha(theme.palette.info.main, 0.3) }}
                />
              ))}
            </Box>
          </Box>
        )}
      </CardContent>
    </Card>
  );
};

export default SkillCard;
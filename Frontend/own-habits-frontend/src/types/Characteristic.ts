import type { Achievement } from './Achievement.tsx';
import type { SkillToCharacteristics } from './SkillToCharacteristics.ts';
import type { UserToCharacteristics } from './UserToCharacteristics.ts';

export interface Characteristic {
  id: string;
  userId: string;
  title: string;
  description?: string;
  level: number;
  currentExperience: number;
  nextLevelExperience: number;
  
  // Навигационные свойства
  requiredSkills: SkillToCharacteristics[];
  completedAchievements: Achievement[];
  userCharacteristics: UserToCharacteristics[];
}
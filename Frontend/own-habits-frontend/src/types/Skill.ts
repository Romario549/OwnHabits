import type { GoalsToSkills } from './GoalsToSkills';
import type { SkillToCharacteristics } from './SkillToCharacteristics';
import type { UserToSkills } from './UserToSkills';

export interface Skill {
  id: string;
  userId: string;
  title: string;
  description?: string;
  level: number;
  currentExperience: number;
  nextLevelExperience: number;
  
  // Навигационные свойства
  upgradableCharacteristics: SkillToCharacteristics[];
  experiencedGoals: GoalsToSkills[];
  userSkills: UserToSkills[];
}
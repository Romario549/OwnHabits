import type { Goal } from './Goal';
import type { Skill } from './Skill';

export interface GoalsToSkills {
  id: string;
  goalId: string;
  skillId: string;
  goal?: Goal;
  skill?: Skill;
}
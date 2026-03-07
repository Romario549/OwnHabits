import type { User } from './User';
import type { Skill } from './Skill';

export interface UserToSkills {
  id: string;
  userId: string;
  skillId: string;
  user?: User;
  skill?: Skill;
}
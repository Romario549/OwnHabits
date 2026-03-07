import type { UserToGoals } from './UserToGoals';
import type { UserToSkills } from './UserToSkills';
import type { UserToCharacteristics } from './UserToCharacteristics';

export type PersonGrade = 'Newbie' | 'Beginner' | 'Intermediate' | 'Advanced' | 'Expert' | 'Master';

export interface User {
  id: string;
  userName: string;
  email: string;
  completedGoals: number;
  grade: PersonGrade;

  goals: UserToGoals[];
  skills: UserToSkills[];
  characteristics: UserToCharacteristics[];
}
import type { User } from './User';
import type { Goal } from './Goal';

export interface UserToGoals {
  id: string;
  userId: string;
  goalId: string;
  user?: User;
  goal?: Goal;
}
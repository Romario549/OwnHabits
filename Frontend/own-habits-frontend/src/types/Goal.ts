import type { GoalsToSkills } from "./GoalsToSkills";
import type { UserToGoals } from "./UserToGoals";

export type Status = 'InProgress' | 'Completed' | 'Failed' | 'Cancelled';
export type Priority = 'Low' | 'Normal' | 'High' | 'Urgent';
export type Difficulty = 'Easy' | 'Medium' | 'Hard' | 'Extreme';

export interface Goal {
  id: string;
  userId: string;
  title: string;
  description?: string;
  createdAt: string;
  deadline: string;
  status: Status;
  priority: Priority;
  difficulty: Difficulty;
  repeatability: boolean;
  gainedExperience: number;
  penalty: number;
  
  // Навигационные свойства
  upgradableSkills: GoalsToSkills[];
  userGoals: UserToGoals[];
}
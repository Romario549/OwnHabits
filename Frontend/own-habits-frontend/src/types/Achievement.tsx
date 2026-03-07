import type { Characteristic } from "./Characteristic";

export interface Achievement {
  id: string;
  title: string;
  conditionToGet: string;
  isAchieved: boolean;
  dateAchieved: string;
  experience: number;
  characteristicId: string;
  characteristicToUpgrade?: Characteristic;
}
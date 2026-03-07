import type { Skill } from './Skill';
import type { Characteristic } from './Characteristic';

export interface SkillToCharacteristics {
  id: string;
  skillId: string;
  characteristicId: string;
  skill?: Skill;
  characteristic?: Characteristic;
}
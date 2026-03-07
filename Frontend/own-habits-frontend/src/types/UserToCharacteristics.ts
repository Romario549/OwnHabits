import type { User } from './User';
import type { Characteristic } from './Characteristic';

export interface UserToCharacteristics {
  id: string;
  userId: string;
  characteristicId: string;
  user?: User;
  characteristic?: Characteristic;
}
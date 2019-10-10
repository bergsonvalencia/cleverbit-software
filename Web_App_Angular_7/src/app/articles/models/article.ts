import { Comment } from './comment';
import { Guid } from 'guid-typescript';

export interface Article {
  id: Guid;
  name: string;
  content: string;
  year: number;
  comments: Comment[];
}

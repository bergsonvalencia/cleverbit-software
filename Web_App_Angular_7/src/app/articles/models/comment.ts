import { Guid } from 'guid-typescript';
import { Article } from './article';

export interface Comment {
  id: Guid;
  commenterId: string;
  content: string;
  articleId: Guid;
  article: Article;
}

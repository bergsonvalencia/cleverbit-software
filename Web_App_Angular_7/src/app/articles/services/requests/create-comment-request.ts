import { Guid } from 'guid-typescript';

export interface CreateCommentRequest {
  CommenterId: string;
  Content: string;
  ArticleId: Guid;
}

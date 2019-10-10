import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { catchError, tap, map } from 'rxjs/operators';
import { Comment } from '../models';
import { Guid } from 'guid-typescript';
import { environment } from 'src/environments/environment';
import { CreateCommentRequest } from './requests/create-comment-request';
import { LoggerService } from 'src/app/core/services/logger.service';

@Injectable({
  providedIn: 'root'
})
export class CommentService {
  private baseUrl: string;

  constructor(private http: HttpClient, private logger: LoggerService) {
    this.baseUrl = environment.apiUrl + '/comments';
  }

  createComment(
    commenterId: string,
    articleId: Guid,
    content: string
  ): Observable<Comment> {
    let request: CreateCommentRequest = {
      CommenterId: commenterId,
      Content: content,
      ArticleId: articleId
    };

    return this.http
      .post<CreateCommentRequest>(`${this.baseUrl}/create`, request)
      .pipe(
        map(response => this.mapComment(response)),
        catchError(this.logger.handleCatchError)
      );
  }

  private mapComment(data: any): Comment {
    return <Comment>data.comment;
  }
}

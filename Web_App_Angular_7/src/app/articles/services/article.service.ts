import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { catchError, tap, map } from 'rxjs/operators';
import { Article } from '../models';
import { Guid } from 'guid-typescript';
import { environment } from 'src/environments/environment';
import { LoggerService } from 'src/app/core/services/logger.service';

@Injectable({
  providedIn: 'root'
})
export class ArticleService {
  private baseUrl: string;

  constructor(private http: HttpClient, private logger: LoggerService) {
    this.baseUrl = environment.apiUrl + '/articles';
  }

  getArticles(): Observable<Article[]> {
    return this.http.get<Article[]>(`${this.baseUrl}`).pipe(
      map(response => this.mapArticles(response)),
      catchError(this.logger.handleCatchError)
    );
  }

  getArticle(id: Guid): Observable<Article> {
    return this.http.get<Article>(`${this.baseUrl}/${id}`).pipe(
      map(response => this.mapArticle(response)),
      catchError(this.logger.handleCatchError)
    );
  }

  private mapArticles(data: any): Article[] {
    return <Article[]>data.articles;
  }

  private mapArticle(data: any): Article {
    return <Article>data.article;
  }
}

import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Guid } from 'guid-typescript';
import { Article, Comment } from '../models';
import { ArticleService } from '../services/article.service';
import { CommentService } from '../services/comment.service';
import {
  GrowlerService,
  GrowlerMessageType
} from 'src/app/core/growler/growler.service';
import { UserAuthenticationService } from 'src/app/core/services/user-authentication.service';

@Component({
  templateUrl: './article-detail.component.html',
  styleUrls: ['./article-detail.component.scss']
})
export class ArticleDetailComponent implements OnInit {
  errorMessage = '';
  article: Article | undefined;
  comment: Comment;
  isPopular: boolean;
  commentContent: string;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private articleService: ArticleService,
    private commentService: CommentService,
    private userAuthService: UserAuthenticationService,
    private growler: GrowlerService
  ) {}

  ngOnInit() {
    this.setArticle();
  }

  setArticle() {
    const param = this.route.snapshot.paramMap.get('id');
    if (param) {
      this.getArticle(Guid.parse(param));
    }
  }

  getArticle(id: Guid) {
    this.articleService.getArticle(id).subscribe(
      article => {
        this.article = article;
        this.isPopular = this.article.comments.length > 5;
      },
      error => (this.errorMessage = <any>error)
    );
  }

  onBack(): void {
    this.router.navigate(['/articles']);
  }

  onComment(): void {
    if (this.userAuthService.isAuthenticated) {
      if (!this.commentContent) {
        this.growler.growl(
          'Please input comment before proceeding',
          GrowlerMessageType.Warning
        );
        return;
      }
      this.commentService
        .createComment(
          this.userAuthService.userEmail,
          this.article.id,
          this.commentContent
        )
        .subscribe(res => {
          this.growler.growl('Comment successful', GrowlerMessageType.Success);
          this.comment = res;
          this.setArticle();
        });
    } else {
      this.growler.growl(
        'Please sign in with Google before proceeding',
        GrowlerMessageType.Warning
      );
    }
  }
}

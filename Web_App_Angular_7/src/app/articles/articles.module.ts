import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ArticleDetailComponent } from './article-detail/article-detail.component';
import { ArticleListComponent } from './article-list/article-list.component';



@NgModule({
  declarations: [ArticleDetailComponent, ArticleListComponent],
  imports: [
    CommonModule
  ]
})
export class ArticlesModule { }

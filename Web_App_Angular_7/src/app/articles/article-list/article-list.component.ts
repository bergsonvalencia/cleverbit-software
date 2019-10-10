import { Component, OnInit } from '@angular/core';
import { Article } from '../models';
import { ArticleService } from '../services/article.service';

@Component({
  templateUrl: './article-list.component.html',
  styleUrls: ['./article-list.component.scss']
})
export class ArticleListComponent implements OnInit {
  imageWidth = 200;
  imageMargin = 2;
  showImage = false;
  errorMessage = '';
  filteredArticles: Article[] = [];
  articles: Article[] = [];

  constructor(private articleService: ArticleService) {}

  ngOnInit(): void {
    this.getArticles();
  }

  getArticles() {
    this.articleService.getArticles().subscribe(
      articles => {
        this.articles = articles;
        this.filteredArticles = this.articles;
      },
      error => (this.errorMessage = <any>error)
    );
  }

  _listFilter = '';
  get listFilter(): string {
    return this._listFilter;
  }
  set listFilter(value: string) {
    this._listFilter = value;
    this.filteredArticles = this.listFilter
      ? this.performFilter(this.listFilter)
      : this.articles;
  }

  performFilter(filterBy: string): Article[] {
    filterBy = filterBy.toLocaleLowerCase();
    return this.articles.filter(
      (article: Article) =>
        article.name.toLocaleLowerCase().indexOf(filterBy) !== -1 ||
        article.content
          .toString()
          .toLocaleLowerCase()
          .indexOf(filterBy) !== -1 ||
        article.year
          .toString()
          .toLocaleLowerCase()
          .indexOf(filterBy) !== -1
    );
  }
}

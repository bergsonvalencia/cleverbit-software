import { NgModule } from '@angular/core';
import { SharedModule } from '../shared/shared.module';
import { ReactiveFormsModule } from '@angular/forms';
import { ArticlesRoutingModule } from './articles-routing.module';

@NgModule({
  imports: [ArticlesRoutingModule, SharedModule, ReactiveFormsModule],
  declarations: [ArticlesRoutingModule.components]
})
export class ArticlesModule {}

import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { CoreModule } from './core/core.module';
import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';

@NgModule({
  declarations: [AppRoutingModule.components],
  imports: [BrowserModule, CoreModule, AppRoutingModule],
  bootstrap: [AppComponent]
})
export class AppModule {}

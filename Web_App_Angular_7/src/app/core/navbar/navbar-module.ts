import { NgModule } from '@angular/core';
import { SocialLoginModule, AuthServiceConfig } from 'angularx-social-login';
import { GoogleLoginProvider } from 'angularx-social-login';
import { NavbarComponent } from './navbar.component';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { environment } from 'src/environments/environment';

let config = new AuthServiceConfig([
  {
    id: GoogleLoginProvider.PROVIDER_ID,
    provider: new GoogleLoginProvider(environment.googleLoginProvider)
  }
]);

export function provideConfig() {
  return config;
}

@NgModule({
  providers: [
    {
      provide: AuthServiceConfig,
      useFactory: provideConfig
    }
  ],
  imports: [CommonModule, RouterModule, SocialLoginModule],
  exports: [NavbarComponent],
  declarations: [NavbarComponent]
})
export class NavbarModule {}

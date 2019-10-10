import { Component, OnInit } from '@angular/core';
import {
  AuthService,
  GoogleLoginProvider,
  SocialUser
} from 'angularx-social-login';
import { UserAuthenticationService } from '../services/user-authentication.service';


@Component({
  selector: 'as-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent implements OnInit {
  private user: SocialUser;
  private loggedIn: boolean;
  constructor(
    private authService: AuthService,
    private userAuthenticationService: UserAuthenticationService
  ) {}
  ngOnInit(): void {
    this.authenticateUser();
  }

  authenticateUser(): void {
    this.authService.authState.subscribe(user => {
      this.user = user;
      this.loggedIn = user != null;
      if (user) {
        this.userAuthenticationService
          .authenticateGoogle(user.idToken)
          .subscribe(res => {
            this.userAuthenticationService.loggedIn(user.email, res.token);
          });
      } else {
        this.userAuthenticationService.loggedOut();
      }
    });
  }

  signInWithGoogle(): void {
    this.authService.signIn(GoogleLoginProvider.PROVIDER_ID);
  }

  signOut(): void {
    this.authService.signOut();
  }
}

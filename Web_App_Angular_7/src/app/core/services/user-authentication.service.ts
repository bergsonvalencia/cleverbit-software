import { Injectable, Output, EventEmitter } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { catchError, map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { LoggerService } from 'src/app/core/services/logger.service';

@Injectable({
  providedIn: 'root'
})
@Injectable()
export class UserAuthenticationService {
  isAuthenticated = false;
  token: string;
  userEmail: string;
  redirectUrl: string;
  @Output() authChanged: EventEmitter<boolean> = new EventEmitter<boolean>();

  private baseUrl: string;

  constructor(private http: HttpClient, private logger: LoggerService) {
    this.baseUrl = environment.apiUrl;
  }

  private userAuthChanged(status: boolean) {
    this.authChanged.emit(status);
  }

  loggedIn(userEmail: string, token: string): void {
    this.userAuthChanged(true);
    this.isAuthenticated = true;
    this.userEmail = userEmail;
    this.token = token;
  }

  loggedOut(): void {
    this.userAuthChanged(false);
    this.isAuthenticated = false;
    this.userEmail = '';
    this.token = '';
  }

  authenticateGoogle(idToken: string): Observable<AuthenticateGoogleResponse> {
    return this.http
      .post<FormData>(`${this.baseUrl}/authentication/google`, {
        IdToken: idToken
      })
      .pipe(
        map(response => this.mapAuthenticateGoogleResponse(response)),
        catchError(this.logger.handleCatchError)
      );
  }

  private mapAuthenticateGoogleResponse(data: any): AuthenticateGoogleResponse {
    return <AuthenticateGoogleResponse>data;
  }
}

export class AuthenticateGoogleResponse {
  token: string;
}

import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { UserAuthenticationService, LoggerService } from '../services';
import {
  HttpInterceptor,
  HttpRequest,
  HttpHandler,
  HttpEvent
} from '@angular/common/http';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {
  constructor(private userAuthenticationService: UserAuthenticationService) {}

  intercept(
    req: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    const token = this.userAuthenticationService.token;
    return token ? next.handle(this.addToken(req, token)) : next.handle(req);
  }

  private addToken(req: HttpRequest<any>, token: string): HttpRequest<any> {
    return req.clone({ setHeaders: { Authorization: 'Bearer ' + token } });
  }
}

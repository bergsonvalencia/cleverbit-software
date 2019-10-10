import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpErrorResponse } from '@angular/common/http';
import { throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LoggerService {
  constructor() {}
  log(msg: string) {
    if (environment.development) {
      console.log(msg);
    } else {
      // TODO: Use 3rd party logging service
    }
  }

  logError(msg: string) {
    if (environment.development) {
      console.error(msg);
    } else {
      // TODO: Use 3rd party logging service
    }
  }

  handleCatchError(err: HttpErrorResponse) {
    let errorMessage = '';
    if (err.error instanceof ErrorEvent) {
      // A client-side or network error occurred. Handle it accordingly.
      errorMessage = `An error occurred: ${err.error.message}`;
      this.log(errorMessage);
    } else {
      // The backend returned an unsuccessful response code.
      // The response body may contain clues as to what went wrong,
      errorMessage = `Server returned code: ${err.status}, error message is: ${err.message}`;
      this.logError(errorMessage);
    }
    return throwError(errorMessage);
  }
}

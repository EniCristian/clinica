import {
  HttpEvent,
  HttpHandler,
  HttpInterceptor,
  HttpRequest,
} from '@angular/common/http';
import { UserLanguageService } from './user-language.service';
import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';

@Injectable()
export class HttpTranslationHeaderInterceptor implements HttpInterceptor {
  constructor(private languageService: UserLanguageService) {}

  intercept(
    request: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    request = request.clone({
      setHeaders: {
        'Accept-Language': this.languageService.language,
      },
    });
    return next.handle(request);
  }
}

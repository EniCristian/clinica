import {
  HTTP_INTERCEPTORS,
  HttpEvent,
  HttpHandler,
  HttpInterceptor,
  HttpRequest,
} from '@angular/common/http';
import { Injectable, Provider } from '@angular/core';
import { Observable } from 'rxjs';
import { UserLanguageService } from './user-language.service';

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
    console.log(request);
    return next.handle(request);
  }
}
export const HttpTranslationHeaderInterceptorProvider: Provider = {
  provide: HTTP_INTERCEPTORS,
  useClass: HttpTranslationHeaderInterceptor,
  multi: true,
  deps: [UserLanguageService],
};

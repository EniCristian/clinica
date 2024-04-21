import {
  ApplicationConfig,
  LOCALE_ID,
  importProvidersFrom,
} from '@angular/core';
import { provideRouter } from '@angular/router';
import localeRO from '@angular/common/locales/ro';
import { routes } from './app.routes';
import { provideClientHydration } from '@angular/platform-browser';
import { TranslateLoader, TranslateModule } from '@ngx-translate/core';
import {
  HTTP_INTERCEPTORS,
  HttpClient,
  provideHttpClient,
} from '@angular/common/http';
import { UserLanguageService } from './common/translate/user-language.service';
import { TranslateLoaderService } from './common/translate/http-translate-loader.service';
import { registerLocaleData } from '@angular/common';
import { environment } from './environments/environment';
import { CommonsModule } from './common/commons.module';
import { HttpTranslationHeaderInterceptor } from './common/translate/http-translation-header-interceptor';

export const provideTranslation = () => ({
  defaultLanguage: environment.defaultLanguage,
  loader: {
    provide: TranslateLoader,
    useFactory: createTranslateLoader,
    deps: [HttpClient, UserLanguageService],
  },
});

export function createTranslateLoader(
  httpClient: HttpClient,
  languageService: UserLanguageService
): TranslateLoaderService {
  return new TranslateLoaderService(httpClient, languageService);
}
registerLocaleData(localeRO, 'ro-RO');

const translateModule = TranslateModule.forRoot(provideTranslation());

export const appConfig: ApplicationConfig = {
  providers: [
    CommonsModule,
    provideRouter(routes),
    provideHttpClient(),
    provideClientHydration(),
    importProvidersFrom([translateModule]),
    {
      provide: HTTP_INTERCEPTORS,
      useClass: HttpTranslationHeaderInterceptor,
      multi: true,
    },
    { provide: LOCALE_ID, useValue: environment.defaultLanguage },
  ],
};

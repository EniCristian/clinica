import { ApplicationConfig, importProvidersFrom } from '@angular/core';
import { provideRouter } from '@angular/router';
import { routes } from './app.routes';
import { provideClientHydration } from '@angular/platform-browser';
import { TranslateLoader, TranslateModule } from '@ngx-translate/core';

import { HttpClient, provideHttpClient } from '@angular/common/http';
import { UserLanguageService } from './common/translate/user-language.service';
import { TranslateLoaderService } from './common/translate/http-translate-loader.service';
import { environment } from './environments/environment';
import { CommonsModule } from './common/commons.module';
import { HttpTranslationHeaderInterceptorProvider } from './common/translate/http-translation-header-interceptor';

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
): TranslateLoader {
  return new TranslateLoaderService(httpClient, languageService);
}

const translateModule = TranslateModule.forRoot(provideTranslation());

export const appConfig: ApplicationConfig = {
  providers: [
    CommonsModule,
    HttpTranslationHeaderInterceptorProvider,
    provideRouter(routes),
    provideHttpClient(),
    provideClientHydration(),
    importProvidersFrom([translateModule]),
  ],
};

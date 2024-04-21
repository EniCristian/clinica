import { UserLanguageService } from './user-language.service';
import { Observable } from 'rxjs';
import { TranslateLoader } from '@ngx-translate/core';
import { HttpClient } from '@angular/common/http';

export class TranslateLoaderService implements TranslateLoader {
  constructor(
    private httpClient: HttpClient,
    private languageService: UserLanguageService
  ) {}

  public getTranslation(): Observable<Map<string, string>> {
    return this.languageService.getTranslations();
  }
}

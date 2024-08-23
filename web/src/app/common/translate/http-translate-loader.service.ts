import { UserLanguageService } from './user-language.service';
import { Observable } from 'rxjs';
import { TranslateLoader } from '@ngx-translate/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';

export class TranslateLoaderService implements TranslateLoader {
  constructor(
    private httpClient: HttpClient,
    private languageService: UserLanguageService
  ) {}
  public getTranslation(): Observable<Map<string, string>> {
    const response = this.httpClient.get<Map<string, string>>(
      `${environment.apiBaseUrl}/translations`,
      { headers: { 'Accept-Language': this.languageService.language } }
    );
    return response;
  }
}

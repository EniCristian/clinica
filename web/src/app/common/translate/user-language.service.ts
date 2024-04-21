import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { Injectable } from '@angular/core';

@Injectable({ providedIn: 'root' })
export class UserLanguageService {
  private readonly userLanguageKey: string = 'USER_LANGUAGE';
  private selectedLanguage: BehaviorSubject<string> = new BehaviorSubject('');
  userLanguage: Observable<string> = new Observable();
  constructor(private httpClient: HttpClient) {
    this.selectedLanguage.next(this.language);
    this.userLanguage = this.selectedLanguage.asObservable();
  }

  public get language(): string {
    let selectedLanguage = localStorage.getItem(this.userLanguageKey);
    if (selectedLanguage === null) {
      selectedLanguage = environment.defaultLanguage;
    }
    return selectedLanguage;
  }

  public set language(selectedLanguage: string) {
    localStorage.setItem(this.userLanguageKey, selectedLanguage);
    this.selectedLanguage.next(this.language);
  }

  public getTranslations(): Observable<Map<string, string>> {
    const response = this.httpClient.get<Map<string, string>>(
      `${environment.apiBaseUrl}/translations`
    );
    return response;
  }
}

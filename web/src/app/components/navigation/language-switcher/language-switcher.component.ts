import { Component, OnInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { UserLanguageService } from '../../../common/translate/user-language.service';
import { environment } from '../../../environments/environment';
import { CommonModule, registerLocaleData } from '@angular/common';

@Component({
  selector: 'app-language-switcher',
  templateUrl: './language-switcher.component.html',
  styleUrl: './language-switcher.component.scss',
})
export class LanguageSwitcherComponent implements OnInit {
  language: string = 'ro-RO';
  constructor(
    private translate: TranslateService,
    private userLanguageService: UserLanguageService
  ) {
    this.translate.addLangs(['ro-RO', 'en-US']);
    this.translate.setDefaultLang(environment.defaultLanguage);
    userLanguageService.userLanguage.subscribe((language) => {
      this.language = language;
      this.translate.reloadLang(language);
      registerLocaleData(language);
      this.translate.use(language);
    });
  }

  ngOnInit(): void {}

  changeLanguage(): void {
    let chosenLanguage = '';
    if (this.language === 'en-US') {
      chosenLanguage = 'ro-RO';
    } else {
      chosenLanguage = 'en-US';
    }
    this.userLanguageService.language = chosenLanguage;
  }
}

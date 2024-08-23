import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HeaderComponent } from './header/header.component';
import { HeaderNavigatorComponent } from './header-navigator/header-navigator.component';
import { CommonsModule } from '../../common/commons.module';
import { LanguageSwitcherComponent } from './language-switcher/language-switcher.component';

@NgModule({
  declarations: [
    HeaderComponent,
    HeaderNavigatorComponent,
    LanguageSwitcherComponent,
  ],
  exports: [
    HeaderComponent,
    HeaderNavigatorComponent,
    LanguageSwitcherComponent,
  ],
  imports: [CommonModule, CommonsModule],
})
export class NavigationModule {}

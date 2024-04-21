import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { BannerComponent } from './components/banner/banner.component';
import { FooterComponent } from './components/layout/footer/footer.component';
import { NavigationModule } from './components/navigation/navigation.module';
import { TranslateService } from '@ngx-translate/core';
import { environment } from './environments/environment';

@Component({
  selector: 'app-root',
  standalone: true,
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss',
  imports: [RouterOutlet, BannerComponent, FooterComponent, NavigationModule],
})
export class AppComponent {
  constructor(private translateService: TranslateService) {
    this.translateService.use(`${environment.defaultLanguage}`);
  }
  title = 'clinica-web';
}

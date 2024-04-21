import { Component } from '@angular/core';
import { CommonsModule } from '../../../common/commons.module';

@Component({
  selector: 'app-home-banner',
  standalone: true,
  imports: [CommonsModule],
  templateUrl: './home-banner.component.html',
  styleUrl: './home-banner.component.scss',
})
export class HomeBannerComponent {}

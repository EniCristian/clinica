import { Component } from '@angular/core';
import { BannerItem } from '../../banner/banner-item';

@Component({
  selector: 'app-doctors-page',
  templateUrl: './doctors-page.component.html',
  styleUrl: './doctors-page.component.scss',
})
export class DoctorsPageComponent {
  banner: BannerItem = {
    small: true,
    title: 'medics_our_medics',
    routes: [
      { title: 'home_title', path: '/' },
      { title: 'medics_title', path: '/doctors' },
    ],
  };
}

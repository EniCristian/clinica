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
    title: 'doctors_our_doctors',
    routes: [
      { title: 'home_title', path: '/' },
      { title: 'doctors_title', path: '/doctors' },
    ],
  };
}

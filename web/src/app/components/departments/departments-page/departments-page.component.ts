import { Component } from '@angular/core';
import { BannerItem } from '../../banner/banner-item';

@Component({
  selector: 'app-departments-page',
  templateUrl: './departments-page.component.html',
  styleUrl: './departments-page.component.scss',
})
export class DepartmentsPageComponent {
  banner: BannerItem = {
    small: true,
    title: 'departments_title',
    routes: [
      { title: 'home_title', path: '/' },
      { title: 'departments_title', path: '/departments' },
    ],
  };
}

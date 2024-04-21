import { Component } from '@angular/core';
import { BannerComponent } from '../../banner/banner.component';
import { BannerItem } from '../../banner/banner-item';

@Component({
  selector: 'app-contact-page',
  templateUrl: './contact-page.component.html',
  styleUrl: './contact-page.component.scss',
})
export class ContactPageComponent {
  banner: BannerItem = {
    small: true,
    title: 'contact_contact_us',
    routes: [
      { title: 'home_title', path: '/' },
      { title: 'contact_contact_us', path: '/contact' },
    ],
  };
}

import { Component } from '@angular/core';
import { BannerItem } from '../../banner/banner-item';

@Component({
  selector: 'app-create-appointment-page',
  templateUrl: './create-appointment-page.component.html',
  styleUrl: './create-appointment-page.component.scss',
})
export class CreateAppointmentPageComponent {
  banner: BannerItem = {
    small: true,
    title: 'appointment_title',
    routes: [
      { title: 'home_title', path: '/' },
      { title: 'appointment_title', path: '/appointment' },
    ],
  };
}

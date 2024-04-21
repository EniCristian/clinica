import { Component } from '@angular/core';
import { AppointmentModule } from '../../appointment/appointment.module';
import { DoctorsModule } from '../../doctors/doctors.module';
import { EmergencyCallComponent } from '../../emergency-call/emergency-call.component';
import { DepartmentsModule } from '../../departments/departments.module';
import { HomeBannerComponent } from '../home-banner/home-banner.component';

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrl: './home-page.component.scss',
  standalone: true,
  imports: [
    AppointmentModule,
    DoctorsModule,
    EmergencyCallComponent,
    HomeBannerComponent,
    DepartmentsModule,
  ],
})
export class HomePageComponent {}

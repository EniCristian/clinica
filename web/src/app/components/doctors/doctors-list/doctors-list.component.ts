import { Component } from '@angular/core';
import { Doctor } from '../doctor/doctor.model';
import { DoctorsService } from '../services/doctors.service';

@Component({
  selector: 'app-doctors-list',
  templateUrl: './doctors-list.component.html',
  styleUrl: './doctors-list.component.scss',
})
export class DoctorsListComponent {
  doctors: Doctor[] | undefined = undefined;
  constructor(private http: DoctorsService) {
    this.loadDoctors();
  }

  loadDoctors() {
    this.http.getDoctors().subscribe({
      next: (data: Doctor[] | undefined) => {
        this.doctors = data ? data : undefined;
        console.log('Doctors loaded', this.doctors);
      },
      error: (error) => console.error('Failed to load doctors', error),
    });
  }
}

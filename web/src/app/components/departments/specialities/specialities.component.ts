import { Component } from '@angular/core';
import { OwlOptions } from 'ngx-owl-carousel-o';
import { Speciality as SpecialityModel } from '../../admin/specialities/models/speciality.model';
import { SpecialitiesService } from '../../admin/specialities/servicies/speciliaty.service';

@Component({
  selector: 'app-specialities',
  templateUrl: './specialities.component.html',
  styleUrl: './specialities.component.scss',
})
export class SpecialitiesComponent {
  specialities: SpecialityModel[] | undefined;

  constructor(private http: SpecialitiesService) {
    this.loadDoctors();
  }

  loadDoctors() {
    this.http.getSpecialities().subscribe({
      next: (data: SpecialityModel[] | undefined) => {
        this.specialities = data ? data : undefined;
      },
      error: (error) => console.error('Failed to load specialities', error),
    });
  }

  customOptions: OwlOptions = {
    nav: false,
    autoplay: true,
    autoplaySpeed: 1000,
    autoplayTimeout: 1000,
    loop: false,
    rewind: true,
    autoplayHoverPause: true,
    smartSpeed: 1000,
    responsive: {
      0: {
        items: 1,
      },
      400: {
        items: 2,
      },
      740: {
        items: 3,
      },
      940: {
        items: 4,
      },
    },
  };
}

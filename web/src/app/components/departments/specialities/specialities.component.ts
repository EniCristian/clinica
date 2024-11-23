import { Component } from '@angular/core';
import { OwlOptions } from 'ngx-owl-carousel-o';
import { SpecialityDetails } from './speciality.model';

@Component({
  selector: 'app-specialities',
  templateUrl: './specialities.component.html',
  styleUrl: './specialities.component.scss',
})
export class SpecialitiesComponent {
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

  specialities: SpecialityDetails[] = [
    {
      imagePath: 'assets/images/department1.jpg',
      title: 'Cardiology',
      description:
        'Our cardiology department provides the best care for your heart. We have the best doctors and equipment to provide you with the best care.',
    },
    {
      imagePath: 'assets/images/department2.jpg',
      title: 'Neurology',
      description:
        'Our neurology department provides the best care for your brain. We have the best doctors and equipment to provide you with the best care.',
    },
    {
      imagePath: 'assets/images/department3.jpg',
      title: 'Orthopedics',
      description:
        'Our orthopedics department provides the best care for your bones. We have the best doctors and equipment to provide you with the best care.',
    },
    {
      imagePath: 'assets/images/department1.jpg',
      title: 'Dermatology',
      description:
        'Our dermatology department provides the best care for your skin. We have the best doctors and equipment to provide you with the best care.',
    },
    {
      imagePath: 'assets/images/department2.jpg',
      title: 'Gynecology',
      description:
        'Our gynecology department provides the best care for your reproductive system. We have the best doctors and equipment to provide you with the best care.',
    },
    {
      imagePath: 'assets/images/department3.jpg',
      title: 'Oncology',
      description:
        'Our oncology department provides the best care for your cancer. We have the best doctors and equipment to provide you with the best care.',
    },
    {
      imagePath: 'assets/images/department1.jpg',
      title: 'Ophthalmology',
      description:
        'Our ophthalmology department provides the best care for your eyes. We have the best doctors and equipment to provide you with the best care.',
    },
    {
      imagePath: 'assets/images/department2.jpg',
      title: 'Pediatrics',
      description:
        'Our pediatrics department provides the best care for your children. We have the best doctors and equipment to provide you with the best care.',
    },
    {
      imagePath: 'assets/images/department3.jpg',
      title: 'Urology',
      description:
        'Our urology department provides the best care for your urinary system. We have the best doctors and equipment to provide you with the best care.',
    },
    {
      imagePath: 'assets/images/department1.jpg',
      title: 'Psychiatry',
      description:
        'Our psychiatry department provides the best care for your mental health. We have the best doctors and equipment to provide you with the best care.',
    },
    {
      imagePath: 'assets/images/department2.jpg',
      title: 'Rheumatology',
      description:
        'Our rheumatology department provides the best care for your joints. We have the best doctors and equipment to provide you with the best care.',
    },
    {
      imagePath: 'assets/images/department3.jpg',
      title: 'Endocrinology',
      description:
        'Our endocrinology department provides the best care for your hormones. We have the best doctors and equipment to provide you with the best care.',
    },
  ];
}

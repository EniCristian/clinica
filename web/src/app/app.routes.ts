import { Routes } from '@angular/router';
import { HomePageComponent } from './components/home/home-page/home-page.component';

export const routes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    component: HomePageComponent,
  },
  {
    path: 'departments',
    loadChildren: () =>
      import('./components/departments/departments.module').then(
        (m) => m.DepartmentsModule
      ),
  },
  {
    path: 'doctors',
    loadChildren: () =>
      import('./components/doctors/doctors.module').then(
        (m) => m.DoctorsModule
      ),
  },
  {
    path: 'appointment',
    loadChildren: () =>
      import('./components/appointment/appointment.module').then(
        (m) => m.AppointmentModule
      ),
  },
  {
    path: 'blog',
    loadChildren: () =>
      import('./components/blog/blog.module').then((m) => m.BlogModule),
  },
  {
    path: 'contact',
    loadChildren: () =>
      import('./components/contact/contact.module').then(
        (m) => m.ContactModule
      ),
  },
];

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
  {
    path: 'auth',
    loadChildren: () =>
      import('./components/auth/auth.module').then((m) => m.AuthModule),
  },
  {
    path: 'appointments',
    loadChildren: () =>
      import('./components/admin/appointments/appointments.module').then(
        (m) => m.AppointmentsModule
      ),
  },
  {
    path: 'specialities',
    loadChildren: () =>
      import('./components/admin/specialities/specialities.module').then(
        (m) => m.SpecialitiesModule
      ),
  },
  {
    path: 'medics',
    loadChildren: () =>
      import('./components/admin/medics/medics.module').then(
        (m) => m.MedicsModule
      ),
  },
];

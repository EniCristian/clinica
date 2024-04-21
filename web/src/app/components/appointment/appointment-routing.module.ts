import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CreateAppointmentPageComponent } from './create-appointment-page/create-appointment-page.component';

const routes: Routes = [
  { path: '', component: CreateAppointmentPageComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
})
export class AppointmentRoutingModule {}

import { RouterModule, Routes } from '@angular/router';
import { AppointmentsTableComponent } from './appointments-table/appointments-table.component';
import { NgModule } from '@angular/core';

const routes: Routes = [
  { path: '', pathMatch: 'full', component: AppointmentsTableComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
})
export class AppointmentsRoutingModule {}

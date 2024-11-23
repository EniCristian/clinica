import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AppointmentsRoutingModule } from './appointments.routing.module';
import { AppointmentsTableComponent } from './appointments-table/appointments-table.component';

@NgModule({
  declarations: [AppointmentsTableComponent],
  imports: [CommonModule, AppointmentsRoutingModule],
})
export class AppointmentsModule {}

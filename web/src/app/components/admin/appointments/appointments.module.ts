import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AppointmentsRoutingModule } from './appointments.routing.module';
import { AppointmentsTableComponent } from './appointments-table/appointments-table.component';
import { CommonsModule } from '../../../common/commons.module';
import { DataTableModule } from '../../data-table/data-table.module';

@NgModule({
  declarations: [AppointmentsTableComponent],
  imports: [CommonsModule, DataTableModule, AppointmentsRoutingModule],
})
export class AppointmentsModule { }

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DataTableModule } from '../../data-table/data-table.module';
import { MedicsTableComponent } from './medics-table/medics-table.component';
import { MedicsRoutingModule } from './medics.routing.module';

@NgModule({
  declarations: [MedicsTableComponent],
  imports: [CommonModule, DataTableModule, MedicsRoutingModule],
})
export class MedicsModule {}

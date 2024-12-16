import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DataTableModule } from '../../data-table/data-table.module';
import { MedicsTableComponent } from './medics-table/medics-table.component';
import { MedicsRoutingModule } from './medics.routing.module';
import { CommonsModule } from '../../../common/commons.module';
import { MedicCreateEditComponent } from './medic-create-edit/medic-create-edit.component';

@NgModule({
  declarations: [MedicsTableComponent, MedicCreateEditComponent],
  imports: [CommonsModule, DataTableModule, MedicsRoutingModule],
})
export class MedicsModule {}

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DataTableModule } from '../../data-table/data-table.module';
import { SpecialitiesTableComponent } from './specialities-table/specialities-table.component';
import { SpecialitiesRoutingModule } from './specialities.routing.module';

@NgModule({
  declarations: [SpecialitiesTableComponent],
  imports: [CommonModule, DataTableModule, SpecialitiesRoutingModule],
})
export class SpecialitiesModule {}

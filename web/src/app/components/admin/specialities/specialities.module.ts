import { NgModule } from '@angular/core';
import { DataTableModule } from '../../data-table/data-table.module';
import { SpecialitiesTableComponent } from './specialities-table/specialities-table.component';
import { SpecialitiesRoutingModule } from './specialities.routing.module';
import { CommonsModule } from '../../../common/commons.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SpecialitiesCreateEditComponent } from './specialities-create-edit/specialities-create-edit.component';

@NgModule({
  declarations: [SpecialitiesTableComponent, SpecialitiesCreateEditComponent],
  imports: [
    CommonsModule,
    DataTableModule,
    SpecialitiesRoutingModule
  ],
})
export class SpecialitiesModule {}

import { RouterModule, Routes } from '@angular/router';
import { NgModule } from '@angular/core';
import { SpecialitiesTableComponent } from './specialities-table/specialities-table.component';
import { SpecialitiesCreateEditComponent } from './specialities-create-edit/specialities-create-edit.component';

const routes: Routes = [
  { path: '', pathMatch: 'full', component: SpecialitiesTableComponent },
  {
    path: 'create-edit/:id',
    pathMatch: 'full',
    component: SpecialitiesCreateEditComponent
  },
  {
    path: 'create-edit',
    pathMatch: 'full',
    component: SpecialitiesCreateEditComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
})
export class SpecialitiesRoutingModule {}

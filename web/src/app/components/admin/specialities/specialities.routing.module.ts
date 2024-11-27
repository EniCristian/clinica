import { RouterModule, Routes } from '@angular/router';
import { NgModule } from '@angular/core';
import { SpecialitiesTableComponent } from './specialities-table/specialities-table.component';
import { SpecialitiesCreateEditComponent } from './specialities-create-edit/specialities-create-edit.component';

const routes: Routes = [
  { path: '', pathMatch: 'full', component: SpecialitiesTableComponent },
  {
    path: 'create-edit',
    component: SpecialitiesCreateEditComponent,
    children: [
      { path: '', pathMatch: 'full', component: SpecialitiesTableComponent },
      { path: ':id', pathMatch: 'full', component: SpecialitiesTableComponent },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
})
export class SpecialitiesRoutingModule {}

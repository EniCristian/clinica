import { RouterModule, Routes } from '@angular/router';
import { NgModule } from '@angular/core';
import { MedicsTableComponent } from './medics-table/medics-table.component';
import { MedicCreateEditComponent } from './medic-create-edit/medic-create-edit.component';

const routes: Routes = [
  { path: '', pathMatch: 'full', component: MedicsTableComponent },
  { path: 'create-edit', component: MedicCreateEditComponent },
  { path: 'create-edit/:id', component: MedicCreateEditComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
})
export class MedicsRoutingModule {}

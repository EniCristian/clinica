import { RouterModule, Routes } from '@angular/router';
import { NgModule } from '@angular/core';
import { MedicsTableComponent } from './medics-table/medics-table.component';

const routes: Routes = [
  { path: '', pathMatch: 'full', component: MedicsTableComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
})
export class MedicsRoutingModule {}

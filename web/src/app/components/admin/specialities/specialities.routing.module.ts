import { RouterModule, Routes } from '@angular/router';
import { NgModule } from '@angular/core';
import { SpecialitiesTableComponent } from './specialities-table/specialities-table.component';

const routes: Routes = [
  { path: '', pathMatch: 'full', component: SpecialitiesTableComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
})
export class SpecialitiesRoutingModule {}

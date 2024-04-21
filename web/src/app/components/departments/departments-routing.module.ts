import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DepartmentsPageComponent } from './departments-page/departments-page.component';

const routes: Routes = [{ path: '', component: DepartmentsPageComponent }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
})
export class DepartmentsRoutingModule {}

import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DoctorsPageComponent } from './doctors-page/doctors-page.component';

const routes: Routes = [{ path: '', component: DoctorsPageComponent }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
})
export class DoctorsRoutingModule {}

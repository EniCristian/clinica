import { RouterModule, Routes } from '@angular/router';
import { NgModule } from '@angular/core';
import { ProfileEditComponent } from './profile-edit/profile-edit.component';

const routes: Routes = [
  { path: '', pathMatch: 'full', component: ProfileEditComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
})
export class ProfileRoutingModule {}

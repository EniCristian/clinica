import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProfileEditComponent } from './profile-edit/profile-edit.component';
import { ProfileRoutingModule } from './profile.routing.module';

@NgModule({
  declarations: [ProfileEditComponent],
  imports: [CommonModule, ProfileRoutingModule],
})
export class ProfileModule {}

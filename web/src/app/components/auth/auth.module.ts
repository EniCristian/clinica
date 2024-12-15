import { NgModule } from '@angular/core';
import { CommonsModule } from '../../common/commons.module';
import { AuthRoutingModule } from './auth-routing.module';
import { LoginComponent } from './login/login.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ProfileEditComponent } from './profile-edit/profile-edit.component';
import { SettingsComponent } from './settings/settings.component';
import { ProfileComponent } from './profile/profile.component';

@NgModule({
  declarations: [LoginComponent, ProfileEditComponent, SettingsComponent, ProfileComponent],
  imports: [CommonsModule, AuthRoutingModule, FormsModule, ReactiveFormsModule],
  exports: [ProfileComponent],
})
export class AuthModule {}

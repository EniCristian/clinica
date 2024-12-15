import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AccountConfirmationComponent } from './account-confirmation/account-confirmation.component';
import { LoginComponent } from './login/login.component';
import { PasswordResetComponent } from './password-reset/password-reset.component';
import { PasswordResetRequestComponent } from './password-reset-request/password-reset-request.component';
import { SettingsComponent } from './settings/settings.component';
import { ProfileEditComponent } from './profile-edit/profile-edit.component';

const routes: Routes = [
  { path: '', pathMatch: 'full', component: LoginComponent },
  { path: 'login', component: LoginComponent },
  { path: 'password-reset-request', component: PasswordResetRequestComponent },
  { path: 'password-reset', component: PasswordResetComponent },
  { path: 'account-confirmation', component: AccountConfirmationComponent },
  { path: 'settings', component: SettingsComponent },
  { path: 'profile-edit', component: ProfileEditComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
})
export class AuthRoutingModule { }

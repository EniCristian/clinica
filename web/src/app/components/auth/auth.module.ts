import { NgModule } from '@angular/core';
import { CommonsModule } from '../../common/commons.module';
import { AuthRoutingModule } from './auth-routing.module';
import { LoginComponent } from './login/login.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [LoginComponent],
  imports: [CommonsModule, AuthRoutingModule, FormsModule, ReactiveFormsModule],
})
export class AuthModule {}

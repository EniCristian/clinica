import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AppointmentRoutingModule } from './appointment-routing.module';
import { BannerComponent } from '../banner/banner.component';
import { CreateAppointmentPageComponent } from './create-appointment-page/create-appointment-page.component';
import { WelcomeMessageComponent } from './welcome-message/welcome-message.component';
import { CreateAppointmentFormComponent } from './create-appointment-form/create-appointment-form.component';
import { CommonsModule } from '../../common/commons.module';

@NgModule({
  declarations: [
    CreateAppointmentPageComponent,
    WelcomeMessageComponent,
    CreateAppointmentFormComponent,
  ],
  imports: [
    CommonModule,
    CommonsModule,
    AppointmentRoutingModule,
    BannerComponent,
  ],
  exports: [CreateAppointmentFormComponent, WelcomeMessageComponent],
})
export class AppointmentModule {}

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DoctorsRoutingModule } from './doctors-routing.module';
import { BannerComponent } from '../banner/banner.component';
import { DoctorComponent } from './doctor/doctor.component';
import { DoctorsListComponent } from './doctors-list/doctors-list.component';
import { DoctorsPageComponent } from './doctors-page/doctors-page.component';
import { EmergencyCallComponent } from '../emergency-call/emergency-call.component';
import { CommonsModule } from '../../common/commons.module';

@NgModule({
  declarations: [DoctorsPageComponent, DoctorsListComponent, DoctorComponent],
  imports: [
    CommonModule,
    CommonsModule,
    DoctorsRoutingModule,
    BannerComponent,
    EmergencyCallComponent,
  ],
  exports: [DoctorsListComponent],
})
export class DoctorsModule {}

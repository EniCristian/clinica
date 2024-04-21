import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DepartmentsRoutingModule } from './departments-routing.module';
import { BannerComponent } from '../banner/banner.component';
import { DepartmentsPageComponent } from './departments-page/departments-page.component';
import { ClinicQualityComponent } from './clinic-quality/clinic-quality.component';
import { ClinicQualitiesComponent } from './clinic-qualities/clinic-qualities.component';
import { HttpClientModule } from '@angular/common/http';
import { EmergencyCallComponent } from '../emergency-call/emergency-call.component';
import { CommonsModule } from '../../common/commons.module';
import { SpecialitiesComponent } from './specialities/specialities.component';
import { CarouselModule } from 'ngx-owl-carousel-o';

@NgModule({
  declarations: [
    DepartmentsPageComponent,
    ClinicQualitiesComponent,
    ClinicQualityComponent,
    SpecialitiesComponent,
  ],
  imports: [
    CommonModule,
    CommonsModule,
    DepartmentsRoutingModule,
    BannerComponent,
    EmergencyCallComponent,
    CarouselModule,
    HttpClientModule,
  ],

  exports: [ClinicQualitiesComponent, SpecialitiesComponent],
})
export class DepartmentsModule {}

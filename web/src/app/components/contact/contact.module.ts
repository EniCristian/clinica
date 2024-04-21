import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ContactRoutingModule } from './contact-routing.module';
import { ContactFormComponent } from './contact-form/contact-form.component';
import { ContactPageComponent } from './contact-page/contact-page.component';
import { BannerComponent } from '../banner/banner.component';
import { HttpClientModule } from '@angular/common/http';
import { GoogleMapsModule } from '@angular/google-maps';
import { CommonsModule } from '../../common/commons.module';

@NgModule({
  declarations: [ContactFormComponent, ContactPageComponent],
  imports: [
    CommonModule,
    CommonsModule,
    ContactRoutingModule,
    BannerComponent,
    HttpClientModule,
    GoogleMapsModule,
  ],
})
export class ContactModule {}

import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { TranslateModule } from '@ngx-translate/core';
import { MaterialModule } from './material.module';

@NgModule({
  declarations: [],
  providers: [],
  imports: [CommonModule, TranslateModule, MaterialModule],
  exports: [CommonModule, TranslateModule, MaterialModule],
})
export class CommonsModule {}

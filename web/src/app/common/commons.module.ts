import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { TranslateModule } from '@ngx-translate/core';

@NgModule({
  declarations: [],
  providers: [],
  imports: [CommonModule, TranslateModule, HttpClientModule],
  exports: [CommonModule, TranslateModule, HttpClientModule],
})
export class CommonsModule {}

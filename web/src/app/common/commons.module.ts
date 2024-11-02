import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { TranslateModule } from '@ngx-translate/core';
import { MaterialModule } from './material.module';
import { DeleteConfirmationModalComponent } from './delete-confirmation-modal/delete-confirmation-modal.component';

@NgModule({
  declarations: [DeleteConfirmationModalComponent],
  providers: [],
  imports: [CommonModule, TranslateModule, MaterialModule],
  exports: [
    CommonModule,
    TranslateModule,
    MaterialModule,
    DeleteConfirmationModalComponent,
  ],
})
export class CommonsModule {}

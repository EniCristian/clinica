import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { TranslateModule } from '@ngx-translate/core';
import { MaterialModule } from './material.module';
import { DeleteConfirmationModalComponent } from './delete-confirmation-modal/delete-confirmation-modal.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [DeleteConfirmationModalComponent],
  providers: [],
  imports: [CommonModule, TranslateModule, MaterialModule, FormsModule,ReactiveFormsModule],
  exports: [
    CommonModule,
    TranslateModule,
    MaterialModule,
    FormsModule,
    ReactiveFormsModule,
    DeleteConfirmationModalComponent,
  ],
})
export class CommonsModule {}

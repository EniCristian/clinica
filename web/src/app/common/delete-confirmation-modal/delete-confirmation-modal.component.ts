import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-delete-confirmation-modal',
  templateUrl: './delete-confirmation-modal.component.html',
  styleUrls: ['./delete-confirmation-modal.component.scss'],
})
export class DeleteConfirmationModalComponent {
  messageResource: string = 'material_data_table_delete_modal_title';
  title: string = 'material_data_table_delete_modal_title';
  confirmButtonText: string = 'material_data_table_delete_modal_confirm_button';
  cancelButtonText: string = 'material_data_table_delete_modal_cancel_button';
  messageParams: any = {};

  constructor(
    @Inject(MAT_DIALOG_DATA) public data: any,
    public dialogRef: MatDialogRef<DeleteConfirmationModalComponent>
  ) {
    if (data) {
      if (data.message) {
        console.log(data.message);
        this.messageResource = data.message;
      }
      if (data.messageParams) {
        console.log(data.messageParams);
        this.messageParams = data.messageParams;
      }
      if (data.title) {
        console.log(data.title);
        this.title = data.title;
      }
      if (data.confirmButtonText) {
        this.confirmButtonText = data.confirmButtonText;
      }
      if (data.cancelButtonText) {
        this.cancelButtonText = data.cancelButtonText;
      }
    }
  }

  close(): void {
    this.dialogRef.close();
  }
}

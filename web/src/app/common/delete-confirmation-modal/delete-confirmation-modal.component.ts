import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';

@Component({
    selector: 'app-delete-confirmation-modal',
    templateUrl: './delete-confirmation-modal.component.html',
    styleUrls: ['./delete-confirmation-modal.component.scss'],
})
export class DeleteConfirmationModalComponent {
    messageResource: string = 'MATERIAL_DATA_TABLE_DELETE_MODAL_MESSAGE';
    title: string = 'MATERIAL_DATA_TABLE_DELETE_MODAL_TITLE';
    confirmButtonText: string = 'MATERIAL_DATA_TABLE_DELETE_MODAL_CONFIRM_BUTTON';
    cancelButtonText: string = 'MATERIAL_DATA_TABLE_DELETE_MODAL_CANCEL_BUTTON';
    messageParams: any = {};

    constructor(
        @Inject(MAT_DIALOG_DATA) public data: any,
        public dialogRef: MatDialogRef<DeleteConfirmationModalComponent>
    ) {
        if (data) {
            if (data.message) {
                this.messageResource = data.message;
            }
            if (data.messageParams) {
                this.messageParams = data.messageParams;
            }
            if (data.title) {
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

import { Component, OnInit } from '@angular/core';
import { ColumnModel } from '../../../data-table/data-table/model/column.model';

@Component({
  selector: 'app-specialities-table',
  templateUrl: './specialities-table.component.html',
  styleUrl: './specialities-table.component.scss',
})
export class SpecialitiesTableComponent {
  columns: Map<string, ColumnModel> = new Map([
    [
      'name',
      {
        headerName: 'general_name',
        sortable: true,
      },
    ],
    [
      'description',
      {
        headerName: 'general_description',
        sortable: true,
      },
    ],
    [
      'consultationDurationInMinutes',
      {
        headerName: 'specialities_consultation_duration',
        sortable: true,
        class: 'mat-column-actions',
      },
    ],
  ]);

  deleteDialogData = {
    title: 'SPECIALITIES_MODAL_DELETE_TITLE',
    message: 'SPECIALITIES_MODAL_DELETE_MESSAGE',
    messageParams: 'name',
  };
}

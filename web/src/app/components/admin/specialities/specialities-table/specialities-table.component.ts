import { Component, OnInit } from '@angular/core';
import { ColumnModel } from '../../../data-table/data-table/model/column.model';
import { SortModel } from '../../../data-table/data-table/model/sort.model';

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
    title: 'specialities_modal_delete_title',
    message: 'specialities_modal_delete_message',
    messageParams: 'name',
  };

  getSort(): SortModel {
    return {
      order: "asc",
      parameter: "name"
    } as SortModel;
  }
}

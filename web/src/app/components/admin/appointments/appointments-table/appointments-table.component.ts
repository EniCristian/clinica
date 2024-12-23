import { Component } from '@angular/core';
import { SortModel } from '../../../data-table/data-table/model/sort.model';
import { ColumnModel } from '../../../data-table/data-table/model/column.model';

@Component({
  selector: 'app-appointments-table',
  templateUrl: './appointments-table.component.html',
  styleUrl: './appointments-table.component.scss',
})
export class AppointmentsTableComponent {
  columns: Map<string, ColumnModel> = new Map([
    [
      'patient.fullName',
      {
        headerName: 'general_surname',
        sortable: true,
      },
    ],
    [
      'patient.phoneNumber',
      {
        headerName: 'general_phone_number',
        sortable: true,
      },
    ],
    ['patient.email', { headerName: 'general_email', sortable: false }],

    [
      'medic.firstName + medic.lastName',
      {
        headerName: 'medics_single_name',
        sortable: true,
      },
    ],
    [
      'medic.speciality.name',
      {
        headerName: 'specialities_single_name',
        sortable: true,
      },
    ],
    [
      'date',
      {
        headerName: 'general_date',
        specialType: 'date',
        sortable: true,
      },
    ],
  ]);

  deleteDialogData = {
    title: 'appointment_modal_delete_title',
    message: 'appointment_modal_delete_message',
    messageParams: ['title', 'patient.fullName', 'date'],
  };

  public getSort(): SortModel {
    return {
      order: "desc",
      parameter: "startTime"
    } as SortModel;
  }
}

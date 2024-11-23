import { Component, OnInit } from '@angular/core';
import { FilterValueModel } from '../../../data-table/data-table/model/filter-value.model';
import { Observable } from 'rxjs';
import { ColumnModel } from '../../../data-table/data-table/model/column.model';
import { ActionModel } from '../../../data-table/data-table/model/action.model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-medics-table',
  templateUrl: './medics-table.component.html',
  styleUrl: './medics-table.component.scss',
})
export class MedicsTableComponent {
  columns: Map<string, ColumnModel> = new Map([
    [
      'lastName',
      {
        headerName: 'specialists_last_name_table_header',
        sortable: true,
      },
    ],
    [
      'firstName',
      {
        headerName: 'specialists_first_name_table_header',
        sortable: true,
      },
    ],
    [
      'speciality.name',
      {
        headerName: 'specialists_specialities_table_header',
        sortable: false,
      },
    ],
    [
      'phoneNumber',
      {
        headerName: 'specialists_phone_number_table_header',
        sortable: true,
      },
    ],
    ['email', { headerName: 'general_email', sortable: false }],
  ]);

  deleteDialogData = {
    title: 'specialists_modal_delete_title',
    message: 'specialists_modal_delete_messagespecialists_modal_delete_message',
    messageParams: ['title', 'lastName', 'firstName'],
  };

  additionalActions: ActionModel[] = [
    {
      name: 'schedule',
      icon: 'edit_calendar',
      callback: this.additionalActionCallback.bind(this),
    },
  ];

  constructor(private router: Router) {}

  additionalActionCallback(row: any): any {
    const specialistId = row.id;
    const specialistName = row.firstName + ' ' + row.lastName;
    const specialistEmail = row.email;
    this.router.navigateByUrl(
      `/manager/manage-specialists/${specialistId}/schedule`,
      {
        state: { specialistName, specialistEmail },
      }
    );
  }
}

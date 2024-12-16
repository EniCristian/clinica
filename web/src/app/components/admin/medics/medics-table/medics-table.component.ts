import { Component, OnInit } from '@angular/core';
import { ColumnModel } from '../../../data-table/data-table/model/column.model';
import { ActionModel } from '../../../data-table/data-table/model/action.model';
import { Router } from '@angular/router';
import { SortModel } from '../../../data-table/data-table/model/sort.model';

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
        headerName: 'general_surname',
        sortable: true,
      },
    ],
    [
      'firstName',
      {
        headerName: 'general_name',
        sortable: true,
      },
    ],
    [
      'speciality.name',
      {
        headerName: 'specialities_single_name',
        sortable: false,
      },
    ],
    [
      'phoneNumber',
      {
        headerName: 'general_phone_number',
        sortable: true,
      },
    ],
    ['email', { headerName: 'general_email', sortable: false }],
  ]);

  deleteDialogData = {
    title: 'doctors_modal_delete_title',
    message: 'doctors_modal_delete_message',
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
  getSort(): SortModel {
    return {
      order: "asc",
      parameter: "lastName"
    } as SortModel;
  }
}

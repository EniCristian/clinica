import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment';
import { AddAppointmentModel } from '../model/add-appointment-model';
import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class AppointmentService {
  private readonly doctorsUrl = `${environment.apiBaseUrl}/appointment`;

  constructor(private httpClient: HttpClient) {}

  createAppointment(
    model: AddAppointmentModel
  ): Observable<AddAppointmentModel> {
    return this.httpClient.post<AddAppointmentModel>(this.doctorsUrl, model);
  }
}

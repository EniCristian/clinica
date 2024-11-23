import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment';
import { AddAppointmentModel } from '../model/add-appointment-model';
import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { AppointmentModel } from '../../admin/appointments/models/appointment.model';

@Injectable({
  providedIn: 'root',
})
export class AppointmentService {
  private readonly appointmentsUrl = `${environment.apiBaseUrl}/appointment`;

  constructor(private httpClient: HttpClient) {}

  createAppointment(
    model: AddAppointmentModel
  ): Observable<AddAppointmentModel> {
    return this.httpClient.post<AddAppointmentModel>(
      this.appointmentsUrl,
      model
    );
  }

  getAppointments(): Observable<AppointmentModel> {
    return this.httpClient.get<AppointmentModel>(this.appointmentsUrl);
  }
}

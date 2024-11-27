import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../environments/environment';
import { Doctor } from '../../../doctors/doctor/doctor.model';

@Injectable({
  providedIn: 'root',
})
export class DoctorsService {
  private readonly doctorsUrl = `${environment.apiBaseUrl}/medics`;

  constructor(private httpClient: HttpClient) {}

  getDoctors(): Observable<Doctor[]> {
    return this.httpClient.get<Doctor[]>(this.doctorsUrl);
  }
}

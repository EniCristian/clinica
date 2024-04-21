import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Doctor } from '../doctor/doctor.model';

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

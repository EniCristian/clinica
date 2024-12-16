import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../environments/environment';
import { Doctor } from '../../../doctors/doctor/doctor.model';

@Injectable({
  providedIn: 'root',
})
export class DoctorsService {


  private readonly medicsUrl = `${environment.apiBaseUrl}/medics`;
  private readonly headers = new HttpHeaders({
    "Content-Type": "application/json",
    "Accept": "application/json"
  })
  constructor(private httpClient: HttpClient) { }

  getMedics(): Observable<Doctor[]> {
    return this.httpClient.get<Doctor[]>(this.medicsUrl);
  }

  getMedic(id: string): Observable<Doctor> {
    return this.httpClient.get<Doctor>(`${this.medicsUrl}/${id}`);
  }

  add(doctor: Doctor): Observable<any> {
    console.log(doctor);
    return this.httpClient.post(this.medicsUrl, JSON.stringify(doctor), { headers: this.headers });
  }

  edit(doctor: Doctor) {
    return this.httpClient.put(`${this.medicsUrl}`, doctor, { headers: this.headers });
  }

  getMedicsBySpeciality(specialityId: string): Observable<Doctor[]> {
    return this.httpClient.get<Doctor[]>(`${this.medicsUrl}/speciality/${specialityId}`);
  }

}

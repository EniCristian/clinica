import { HttpClient } from '@angular/common/http';
import { environment } from '../../../../environments/environment';
import { Speciality } from '../models/speciality.model';
import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class SpecialitiesService {
  private readonly doctorsUrl = `${environment.apiBaseUrl}/specialities`;

  constructor(private httpClient: HttpClient) {}

  getSpecialities(): Observable<Speciality[]> {
    return this.httpClient.get<Speciality[]>(this.doctorsUrl);
  }
  edit(specialityModel: Speciality): Observable<Speciality> {
    return this.httpClient.put<Speciality>(
      `${environment.apiBaseUrl}/specialities`,
      JSON.stringify(specialityModel)
    );
  }

  add(specialityModel: Speciality): Observable<any> {
    return this.httpClient.post(
      `${environment.apiBaseUrl}/specialities`,
      JSON.stringify(specialityModel)
    );
  }

  get(specialityId: string): Observable<Speciality> {
    return this.httpClient.get<Speciality>(
      `${environment.apiBaseUrl}/specialities/${specialityId}`
    );
  }
}
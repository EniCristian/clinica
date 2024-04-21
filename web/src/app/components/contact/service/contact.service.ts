import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { ContactInformation } from '../contact-form/contact-information.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class ContactService {
  private readonly contactUrl = `${environment.apiBaseUrl}/contact-information`;

  constructor(private httpClient: HttpClient) {}

  getConactInformation(): Observable<ContactInformation> {
    return this.httpClient.get<ContactInformation>(this.contactUrl);
  }
}

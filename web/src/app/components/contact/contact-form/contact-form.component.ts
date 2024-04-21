import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ContactInformation } from './contact-information.model';
import { ContactService } from '../service/contact.service';

@Component({
  selector: 'app-contact-form',
  templateUrl: './contact-form.component.html',
  styleUrl: './contact-form.component.scss',
})
export class ContactFormComponent {
  contactInformation: ContactInformation | undefined;

  constructor(private http: ContactService) {
    this.loadContactInformation();
  }

  loadContactInformation() {
    this.http.getConactInformation().subscribe({
      next: (data: ContactInformation | undefined) =>
        (this.contactInformation = data),
      error: (error) =>
        console.error('Failed to load contact information', error),
    });
  }
}

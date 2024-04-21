import { Component } from '@angular/core';
import { ContactInformation } from '../contact/contact-form/contact-information.model';
import { ContactService } from '../contact/service/contact.service';
import { CommonsModule } from '../../common/commons.module';

@Component({
  selector: 'app-emergency-call',
  standalone: true,
  imports: [CommonsModule],
  templateUrl: './emergency-call.component.html',
  styleUrl: './emergency-call.component.scss',
})
export class EmergencyCallComponent {
  phoneNumber: string | undefined;
  constructor(private http: ContactService) {
    this.loadContactInformation();
  }

  loadContactInformation() {
    this.http.getConactInformation().subscribe({
      next: (data: ContactInformation | undefined) =>
        (this.phoneNumber = data?.phoneNumber),
      error: (error) =>
        console.error('Failed to load contact information', error),
    });
  }
}

import { Component, Input } from '@angular/core';
import { ClinicQuality } from './clinic-quality.model';

@Component({
  selector: 'app-clinic-quality',
  templateUrl: './clinic-quality.component.html',
  styleUrl: './clinic-quality.component.scss',
})
export class ClinicQualityComponent {
  @Input() clinicQuality: ClinicQuality | undefined;
}

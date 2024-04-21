import { Component, Input } from '@angular/core';
import { Doctor } from './doctor.model';

@Component({
  selector: 'app-doctor',
  templateUrl: './doctor.component.html',
  styleUrl: './doctor.component.scss',
})
export class DoctorComponent {
  @Input() doctor: Doctor | undefined;
}

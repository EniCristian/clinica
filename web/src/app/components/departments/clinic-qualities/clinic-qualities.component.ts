import { Component } from '@angular/core';
import { ClinicQuality } from '../clinic-quality/clinic-quality.model';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-clinic-qualities',
  templateUrl: './clinic-qualities.component.html',
  styleUrl: './clinic-qualities.component.scss',
})
export class ClinicQualitiesComponent {
  qualities: ClinicQuality[] | undefined = undefined;
  constructor(private http: HttpClient) {
    this.loadQualitiesData();
  }

  loadQualitiesData() {
    this.http.get<ClinicQuality[]>('/assets/data/qualities.json').subscribe(
      (data: ClinicQuality[]) => {
        this.qualities = data;
      },
      (error: any) => {
        console.error('Failed to load contact information', error);
      }
    );
  }
}

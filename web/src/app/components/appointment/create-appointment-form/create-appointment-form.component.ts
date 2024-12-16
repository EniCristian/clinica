import { Component, OnInit } from '@angular/core';
import { AddAppointmentModel } from '../model/add-appointment-model';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { AppointmentService } from '../services/appointment.service';
import { ToastrService } from 'ngx-toastr';
import { Speciality } from '../../admin/specialities/models/speciality.model';
import { SpecialitiesService } from '../../admin/specialities/servicies/speciliaty.service';
import { DoctorsService } from '../../admin/medics/services/doctors.service';
import { Doctor } from '../../doctors/doctor/doctor.model';

@Component({
  selector: 'app-create-appointment-form',
  templateUrl: './create-appointment-form.component.html',
  styleUrl: './create-appointment-form.component.scss',
})
export class CreateAppointmentFormComponent implements OnInit {
  addAppointmentModel = {} as AddAppointmentModel;
  docForm!: FormGroup;
  today = new Date();
  specialities: Speciality[] | undefined;
  medics: Doctor[] | undefined;
  selectedSpecialityId: string | undefined;
  constructor(
    private appointmentService: AppointmentService,
    private specialitiesService: SpecialitiesService,
    private medicsService: DoctorsService,
    private toastr: ToastrService
  ) {
    this.docForm = this.getFormGroup();
    this.initSpecialities();
  }

  ngOnInit(): void { }

  createAppointment(): void {
    this.addAppointmentModel = {
      ...this.addAppointmentModel,
      ...this.docForm.value,
    };

    this.appointmentService
      .createAppointment(this.addAppointmentModel)
      .subscribe((response) => {
        this.toastr.success('Appointment created successfully');
      });
  }
  private initSpecialities(): void {
    this.specialitiesService.getWithActiveMedics().subscribe((specialities) => {
      this.specialities = specialities;
    });
  }

  private getFormGroup(): FormGroup {
    return new FormGroup({
      name: new FormControl('', [
        Validators.required,
        Validators.pattern('[a-zA-Z-ăĂâÂîÎșȘțȚ]+'),
      ]),
      phoneNumber: new FormControl('', [
        Validators.required,
        Validators.pattern('[0-9]+'),
      ]),
      email: new FormControl('', [
        Validators.email,
      ]),
      message: new FormControl(''),
      medicId: new FormControl('', [Validators.required]),
      specialityId: new FormControl('', [Validators.required]),
    });
  }

  getMedics(value:string): void {
    this.docForm.controls['medicId'].setValue('');
      this.medicsService.getMedicsBySpeciality(value).subscribe((medics) => {
        if (medics.length === 0) {
          this.toastr.error('There are no medics in this speciality');
          this.medics=undefined;
          return;
        }
        this.medics = medics;
      });
  
  }
}

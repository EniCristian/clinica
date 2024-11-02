import { Component, OnInit } from '@angular/core';
import { AddAppointmentModel } from '../model/add-appointment-model';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AppointmentService } from '../services/appointment.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-create-appointment-form',
  templateUrl: './create-appointment-form.component.html',
  styleUrl: './create-appointment-form.component.scss',
})
export class CreateAppointmentFormComponent implements OnInit {
  addAppointmentModel = {} as AddAppointmentModel;
  docForm!: FormGroup;
  today = new Date();
  constructor(
    private appointmentService: AppointmentService,
    private fb: FormBuilder,
    private toastr: ToastrService
  ) {
    this.docForm = this.fb.group({
      name: ['', Validators.required],
      phoneNumber: ['', Validators.required],
      email: [''],
      date: ['', Validators.required],
      message: [''],
    });
  }

  ngOnInit(): void {}

  createAppointment(): void {
    console.log(this.docForm.value);
    this.addAppointmentModel = {
      ...this.addAppointmentModel,
      ...this.docForm.value,
    };

    console.log(this.addAppointmentModel);
    this.appointmentService
      .createAppointment(this.addAppointmentModel)
      .subscribe((response) => {
        this.toastr.success('Appointment created successfully');
      });
  }
}

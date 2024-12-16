import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { NameValidator } from '../../../../common/validators/name.validator';
import { Speciality } from '../../specialities/models/speciality.model';
import { ToastrService } from 'ngx-toastr';
import { TranslateService } from '@ngx-translate/core';
import { ActivatedRoute, Router } from '@angular/router';
import { DoctorsService } from '../services/doctors.service';
import { SpecialitiesService } from '../../specialities/servicies/speciliaty.service';
import { map } from 'rxjs';
import { Doctor } from '../../../doctors/doctor/doctor.model';

@Component({
  selector: 'app-medic-create-edit',
  templateUrl: './medic-create-edit.component.html',
  styleUrl: './medic-create-edit.component.scss'
})
export class MedicCreateEditComponent {
  docForm: FormGroup;
  isEditMode: boolean;
  specialities: Array<Speciality> | undefined;
  title: string;

  constructor(
    private route: ActivatedRoute,
    private doctorsService: DoctorsService,
    private sprcialitiesService: SpecialitiesService,
    private router: Router,
    private toastrService: ToastrService,
    private translateService: TranslateService,
  ) {
    this.initSpecialities();
    this.isEditMode = this.isEdit();
    this.title = this.getTitle();
    this.docForm = this.getFormGroup();
    this.initDocForm();
  }
  getFormGroup(): FormGroup<any> {
    return new FormGroup({
      firstName: new FormControl('', [
        Validators.required,
        Validators.pattern('[a-zA-Z-ăĂâÂîÎșȘțȚ]+'),
        NameValidator.normalized
      ]),
      lastName: new FormControl('', [
        Validators.required,
        Validators.pattern('[a-zA-Z-ăĂâÂîÎșȘțȚ]+'),
        NameValidator.normalized
      ]),
      phoneNumber: new FormControl('', [
        Validators.required,
        Validators.pattern('[0-9]+'),
      ]),
      description: new FormControl(''),
      specialityId: new FormControl('', [Validators.required]),
      email: new FormControl('', [
        Validators.required,
        Validators.email,
        Validators.minLength(5),
      ]),
      consultationPrice: new FormControl('', [
        Validators.required,
        Validators.min(10),
        Validators.max(2000),
      ]),
    })
  }
  getTitle(): string {
    if (this.isEditMode) {
      return 'Editeaza medicul';
    } else {
      return 'Adauga un nou medic';
    }
  }
  isEdit(): boolean {
    return this.route.snapshot.paramMap.get('id') !== null && this.route.snapshot.paramMap.get('id') !== undefined;
  }

  onSubmit(): void {
    let doctorToEdit = this.docForm
      .value as Doctor;
    if (this.isEditMode) {
      doctorToEdit.id = this.route.snapshot.paramMap.get('id')!;
      this.doctorsService
        .edit(doctorToEdit)
        .subscribe(() => {
          this.toastrService.success(
            this.translateService.instant(
              'SPECIALISTS_EDIT_SUCCESS_MESSAGE'
            )
          );

          this.routeToList();
        });
    } else {
      this.doctorsService
        .add(doctorToEdit)
        .subscribe(() => {
          this.toastrService.success(
            this.translateService.instant(
              'SPECIALISTS_ADD_SUCCESS_MESSAGE'
            )
          );

          this.routeToList();
        });
    }
  }

  onCancel(): void {
    this.routeToList();
  }

  private routeToList(): void {
    this.router.navigate(['medics/']);
  }

  private initDocForm(): void {
    if (this.isEditMode) {
      this.doctorsService
        .getMedic(this.route.snapshot.paramMap.get('id')!)
        .pipe(
          map((specialist) => {
            this.docForm = new FormGroup({
              firstName: new FormControl(specialist.firstName, [
                Validators.required,
                Validators.pattern('[a-zA-Z-ăĂâÂîÎșȘțȚ]+'),
                NameValidator.normalized
              ]),
              lastName: new FormControl(specialist.lastName, [
                Validators.required,
                Validators.pattern('[a-zA-Z-ăĂâÂîÎșȘțȚ]+'),
                NameValidator.normalized
              ]),

              email: new FormControl({ value: specialist.email, disabled: true }, [
                Validators.required,
                Validators.email,
                Validators.minLength(5),
              ]),
              phoneNumber: new FormControl(
                specialist.phoneNumber,
                [
                  Validators.required,
                  Validators.pattern('[0-9]+'),
                ]
              ),
              description: new FormControl(
                specialist.description
              ),
              specialityId: new FormControl(
                specialist.speciality.id,
                [Validators.required]
              ),
              consultationPrice: new FormControl(specialist.consultationPrice, [
                Validators.required,
                Validators.min(10),
                Validators.max(2000),
              ])
            });
          })
        )
        .subscribe();
    }
  }

  private initSpecialities(): void {
    this.sprcialitiesService
      .getSpecialities()
      .pipe(
        map((data) => {
          this.specialities = data;
        })
      )
      .subscribe();
  }

  getSubmitButtonResource(): string {
    if (this.isEditMode) {
      return 'general_save';
    } else {
      return 'general_add';
    }
  }

}

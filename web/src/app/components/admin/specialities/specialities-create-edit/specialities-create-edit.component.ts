import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { NameValidator } from '../../../../common/validators/name.validator';
import { Speciality } from '../models/speciality.model';
import { map } from 'rxjs';
import { SpecialitiesService } from '../servicies/speciliaty.service';

@Component({
  selector: 'app-specialities-create-edit',
  templateUrl: './specialities-create-edit.component.html',
  styleUrl: './specialities-create-edit.component.scss',
})
export class SpecialitiesCreateEditComponent {
  docForm: FormGroup;
  speciality: Speciality = {} as Speciality;
  isEditMode: boolean;
  title: string;

  constructor(
    private route: ActivatedRoute,
    private specialityService: SpecialitiesService,
    private router: Router
  ) {
    this.isEditMode = this.isEdit();
    this.title = this.getTitle();
    this.docForm = this.getFormGroup();
    this.initDocForm();
  }

  onSubmit(): void {
    this.speciality = this.docForm.value as Speciality;
    if (this.isEditMode) {
      this.speciality.id = this.route.snapshot.paramMap.get('id')!;
      this.specialityService.edit(this.speciality).subscribe(() => {
        this.router.navigate(['/specialities']);
      });
    } else {
      this.specialityService.add(this.speciality).subscribe(() => {
        this.router.navigate(['/specialities']);
      });
    }
  }

  onCancel(): void {
    this.router.navigate(['/specialities/']);
  }

  private getFormGroup(): FormGroup {
    return new FormGroup({
      name: new FormControl('', [
        Validators.required,
        NameValidator.normalized,
      ]),
      description: new FormControl('', [Validators.required]),
      consultationDurationInMinutes: new FormControl('', [
        Validators.required,
        Validators.pattern('[0-9]+'),
      ]),
    });
  }
  private initDocForm(): void {
    if (this.isEditMode) {
      this.specialityService
        .get(this.route.snapshot.paramMap.get('id')!)
        .pipe(
          map((speciality: Speciality) => {
            this.docForm = new FormGroup({
              name: new FormControl(speciality.name, [
                Validators.required,
                NameValidator.normalized,
              ]),
              description: new FormControl(speciality.description, [
                Validators.required,
              ]),
              consultationDurationInMinutes: new FormControl(
                speciality.consultationDurationInMinutes,
                [Validators.required, Validators.pattern('[0-9]+')]
              ),
            });
          })
        )
        .subscribe();
    }
  }

  private getTitle(): string {
    if (this.isEditMode) {
      return 'Editeaza specializarea';
    } else {
      return 'Adauga o noua specializare';
    }
  }

   getSubmitButtonResource(): string {
    if (this.isEditMode) {
      return 'general_save';
    } else {
      return 'general_add';
    }
  }

  private isEdit(): boolean {
    console.log(this.route.snapshot.paramMap.get('id'));
    return this.route.snapshot.paramMap.get('id') != null;
  }
}

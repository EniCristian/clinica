import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';
import { ToastrService } from 'ngx-toastr';
import { AuthService } from '../auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss',
})
export class LoginComponent implements OnInit {
  authForm: FormGroup;
  loading: boolean = false;
  submitted: boolean = false;
  hidePassword: boolean = true;

  constructor(
    private formBuilder: FormBuilder,
    private router: Router,
    private translateService: TranslateService,
    private toastrService: ToastrService,
    private authService: AuthService
  ) {
    this.authForm = new FormGroup({});
    if (this.authService.isAuthenticated()) {
      this.router.navigate(['']);
    }
  }

  ngOnInit(): void {
    this.authForm = this.formBuilder.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', Validators.required],
    });
  }

  get form(): any {
    return this.authForm.controls;
  }

  onSubmit(): void {
    this.submitted = true;
    if (this.authForm.invalid) {
      this.toastrService.error(
        this.translateService.instant('AUTH_CREDENTIALS_ERROR')
      );
      return;
    }

    this.loading = true;
    this.authService
      .login(this.form.email.value, this.form.password.value)
      .subscribe((data) => {
        if (data.resetPasswordToken) {
          this.router.navigate(['auth/password-reset/'], {
            queryParams: {
              token: data.resetPasswordToken,
              email: this.form.email.value,
            },
          });
        } else {
          this.loading = false;
          this.router.navigate(['']);
        }
      });
  }
}

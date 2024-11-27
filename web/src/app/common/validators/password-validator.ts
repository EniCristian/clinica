import { FormControl, ValidationErrors } from '@angular/forms';

export class PasswordValidator {

    public static strong(control: FormControl): ValidationErrors | null {
        const hasNumber = /\d/.test(control.value);
        const hasUpper = /[A-Z]/.test(control.value);
        const hasLower = /[a-z]/.test(control.value);
        const hasLength = control.value.length > 5;

        const valid = hasNumber && hasUpper && hasLower && hasLength;
        if (!valid) {
            return { strong: true };
        }

        return null;
    }
}

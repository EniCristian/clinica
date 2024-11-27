import { FormControl, ValidationErrors } from '@angular/forms';

export class NameValidator {
  public static normalized(control: FormControl): ValidationErrors | null {
    const containsSpaces = /\s/.test(control.value);
    const containsOnlyUppercases =
      control.value.toUpperCase() === control.value;
    const isLowercaseOnly = control.value.toLowerCase() === control.value;
    const hasFirsLetterUppercase = /^[A-Z]*$/.test(control.value.charAt(0));
    const isAbbreviation = !control.value.split('.').some((p: string) => {
      return p && (p.length !== 1 || p < 'A' || p > 'Z');
    });
    const valid =
      hasFirsLetterUppercase &&
      !(
        isLowercaseOnly ||
        (containsOnlyUppercases && (containsSpaces || !isAbbreviation))
      );
    if (!valid) {
      return { normalized: true };
    }

    return null;
  }
}

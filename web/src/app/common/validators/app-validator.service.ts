import { Injectable } from '@angular/core';
import { FormGroup, ValidatorFn } from '@angular/forms';
@Injectable({
    providedIn: 'root',
})
export class AppValidator {
    Match(firstItemName: string, secondItemName: string): any {
        return (group: FormGroup): void => {
            const firstInput = group.controls[firstItemName];
            const secondInput = group.controls[secondItemName];
            if (firstInput.value !== secondInput.value) {
                return secondInput.setErrors({ notEqual: true });
            } else {
                return secondInput.setErrors(null);
            }
        };
    }

    FromToDate(
        firstItemName: string,
        secondItemName: string,
        errorName: string = 'fromToDate'
    ): any {
        return (group: FormGroup): void => {
            const fromDate = group.controls[firstItemName];
            const toDate = group.controls[secondItemName];
            if (
                fromDate !== null &&
                toDate !== null &&
                fromDate.value &&
                toDate.value &&
                new Date(fromDate.value) >= new Date(toDate.value)
            ) {
                return toDate.setErrors({ [errorName]: true });
            }
        };
    }
}

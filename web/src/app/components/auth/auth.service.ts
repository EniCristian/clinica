import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  hasAccess(roles: string[]): boolean {
    if (roles.length === 0) {
      return true;
    }
    throw new Error('Method not implemented.');
  }
}

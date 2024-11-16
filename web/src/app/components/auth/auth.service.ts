import { Inject, Injectable } from '@angular/core';
import { Token } from './model/auth-token.model';
import { HttpClient } from '@angular/common/http';
import { map, Observable } from 'rxjs';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  constructor(private http: HttpClient) {}
  login(email: string, password: string): Observable<Token> {
    return this.http
      .post<Token>(`${environment.apiBaseUrl}/login`, { email, password })
      .pipe(
        map((token) => {
          if (token.authToken && token.refreshToken) {
          }
          return token;
        })
      );
  }
  isAuthenticated(): boolean {
    return false;
    throw new Error('Method not implemented.');
  }
  hasAccess(roles: string[]): boolean {
    if (roles.length === 0) {
      return true;
    }
    throw new Error('Method not implemented.');
  }
}

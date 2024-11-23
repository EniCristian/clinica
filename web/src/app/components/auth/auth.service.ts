import { Injectable } from '@angular/core';
import { Token } from './model/auth-token.model';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, map, Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { AuthUser } from './model/auth-user.model';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  public currentUser: Observable<AuthUser | null>;
  private currentUserSubject: BehaviorSubject<AuthUser | null>;

  private readonly ACCESS_TOKEN_KEY = 'accessToken';
  private readonly REFRESH_TOKEN_KEY = 'refreshToken';
  private readonly usersUrl = `${environment.apiBaseUrl}/users`;

  constructor(private http: HttpClient) {
    this.currentUserSubject = new BehaviorSubject<AuthUser | null>(
      this.readAuthUserFromStorage()
    );

    this.currentUser = this.currentUserSubject.asObservable();
  }

  logout(): void {
    localStorage.removeItem(this.ACCESS_TOKEN_KEY);
    localStorage.removeItem(this.REFRESH_TOKEN_KEY);
    this.currentUserSubject.next(null);
  }

  readAuthUserFromStorage(): AuthUser | null {
    const token = this.retrieveToken(this.ACCESS_TOKEN_KEY);
    if (!token) {
      return null;
    }

    const tokenPayload = this.parseJwt(token);
    return this.getUserFromPayload(tokenPayload);
  }
  private retrieveToken(key: string): string | null {
    return localStorage.getItem(key);
  }
  login(email: string, password: string): Observable<Token> {
    return this.http
      .post<Token>(`${this.usersUrl}/login`, { email, password })
      .pipe(
        map((token) => {
          if (token.accessToken && token.refreshToken) {
            this.storeToken(token);
            const user = this.readAuthUserFromStorage();
            this.currentUserSubject.next(user);
          }
          return token;
        })
      );
  }

  public get user(): AuthUser | null {
    return this.currentUserSubject.value;
  }

  isAuthenticated(): boolean {
    return this.user != null;
  }

  hasAccess(roles: string[]): boolean {
    if (!this.isAuthenticated()) {
      return false;
    }

    if (!roles) {
      return true;
    }

    return (
      roles && roles.some((role) => this.user?.roles.some((r) => r === role))
    );
  }

  private parseJwt(token: string): any {
    try {
      const tokenWithoutPayload = token.split('.')[1];
      const decodedToken = atob(tokenWithoutPayload);
      return JSON.parse(decodedToken);
    } catch (e) {
      return null;
    }
  }

  private getUserFromPayload(userInfo: any): AuthUser | null {
    console.log('userInfo', userInfo);
    try {
      const authUser: AuthUser = {
        roles: this.getRolesArray(userInfo['role']),
        username: userInfo['sub'],
        firstName: userInfo['firstName'],
        lastName: userInfo['lastName'],
        exp: userInfo['exp'],
        userId: userInfo['userId'],
      };

      return authUser;
    } catch (error) {
      return null;
    }
  }

  private getRolesArray(roles: string | Array<string>): Array<string> {
    let rolesArray = new Array<string>();
    if (typeof roles === 'string') {
      rolesArray.push(roles);
    } else {
      rolesArray = roles;
    }

    return rolesArray;
  }

  private storeToken(token: Token): void {
    localStorage.setItem(this.ACCESS_TOKEN_KEY, token.accessToken);
    localStorage.setItem(this.REFRESH_TOKEN_KEY, token.refreshToken);
  }
}

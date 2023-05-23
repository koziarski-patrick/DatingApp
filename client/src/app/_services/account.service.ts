import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, map } from 'rxjs';
import { User } from '../_models/user';
import { environment } from 'src/environments/environment.development';

@Injectable({
  providedIn: 'root',
})
export class AccountService {
  // This service is used to communicate with the API for account related functionality such as login and register methods (singleton service, lives for the lifetime of the application)
  baseUrl = environment.apiUrl; // The base url is set to the apiUrl from the environment file
  private _currentUserSource = new BehaviorSubject<User | null>(null); // The currentUserSource is used to store the current user (the BehaviorSubject is used to store the current user and emit the user to any component that is subscribed to it)
  _currentUser$ = this._currentUserSource.asObservable(); // The currentUser$ is used to subscribe to the currentUserSource (the $ is a convention used to indicate that the variable is an observable)

  constructor(private http: HttpClient) {} // The HttpClient service is injected into the constructor

  login(model: any) {
    // The login method takes a model as an argument
    return this.http.post<User>(this.baseUrl + 'account/login', model).pipe(
      // (pipe is used to chain rxjs operators)
      map((response: User) => {
        // The login method is using the HttpClient post method to send the model to the API) (map is used to transform the response from the API)
        const user = response; // The response from the API is stored in the user variable
        if (user) {
          // If the user variable has a value
          localStorage.setItem('user', JSON.stringify(user)); // The user object is stored in local storage (the user object is converted to a string using the JSON.stringify method)
          this._currentUserSource.next(user); // The user object is emitted to any component that is subscribed to the currentUserSource
        }
      })
    );
  }

  register(model: any) {
    return this.http.post<User>(this.baseUrl + 'account/register', model).pipe(
      map((user) => {
        // The register method is using the HttpClient post method to send the model to the API) (map is used to transform the response from the API)
        if (user) {
          // If the user variable has a value
          localStorage.setItem('user', JSON.stringify(user)); // The user object is stored in local storage (the user object is converted to a string using the JSON.stringify method)
          this._currentUserSource.next(user); // The user object is emitted to any component that is subscribed to the currentUserSource
        }
      })
    );
  }

  logout() {
    localStorage.removeItem('user'); // The user object is removed from local storage
    this._currentUserSource.next(null); // null is emitted to any component that is subscribed to the currentUserSource (user logged out)
  }

  setCurrentUser(user: User) {
    // The setCurrentUser method takes a user as an argument
    this._currentUserSource.next(user); // The user object is emitted to any component that is subscribed to the currentUserSource
  }
}

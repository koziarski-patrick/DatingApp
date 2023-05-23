import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Survey } from '../_models/survey';
import { environment } from 'src/environments/environment.development';

@Injectable({
  providedIn: 'root',
})
export class SurveyService {
  private apiUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  // getSurveys(): Observable<Survey[]> {
  //   return this.http.get<Survey[]>(`${this.apiUrl}survey`).pipe(
  //     map((surveys: Survey[]) => {
  //       // Transform and map only the required fields
  //       console.log('Surveys retrieved:', surveys);
  //       return surveys.map((survey) => ({
  //         title: survey.title,
  //         description: survey.description,
  //         shareableURL: survey.shareableURL,
  //         // Map other fields as needed
  //       }));
  //     })
  //   );
  // }

  getSurveys(): Observable<Survey[]> { // The getSurveys method is used to retrieve the every survey from the API (via the SurveyService)
    return this.http.get<Survey[]>(
      `${this.apiUrl}survey`,
      this.getHttpOptions(),
    );

  }

  getSurvey(id: string): Observable<Survey> { // retrieve a single survey by its ID
    var userID: number = +id;
    return this.http.get<Survey>(`${this.apiUrl}survey/${userID}`, this.getHttpOptions());
  }

  getHttpOptions() { // The getHttpOptions method is used to retrieve the HTTP headers (grants access to the API endpoints for authenticated users)
    const userString = localStorage.getItem('user'); // Retrieve the token from localStorage
    if (!userString) return;
    const user = JSON.parse(userString);
    return {
      headers: new HttpHeaders({
        Authorization: 'Bearer ' + user.token,
      }),
    };
  }

}

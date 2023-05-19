import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, map } from 'rxjs';
import { Survey } from '../_models/survey';

@Injectable({
  providedIn: 'root',
})
export class SurveyService {
  private apiUrl = 'http://localhost:5289/api/'; // Replace with your API endpoint

  constructor(private http: HttpClient) {}

  getSurveys(): Observable<Survey[]> {
    return this.http.get<Survey[]>(`${this.apiUrl}survey`).pipe(
      map((surveys: Survey[]) => {
        // Transform and map only the required fields
        console.log('Surveys retrieved:', surveys);
        return surveys.map((survey) => ({
          title: survey.title,
          description: survey.description,
          shareableURL: survey.shareableURL,
          // Map other fields as needed
        }));
      })
    );
  }
}

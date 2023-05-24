import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Answer } from '../_models/answer';

@Injectable({
  providedIn: 'root',
})
export class AnswerService {
  private apiUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  getAnswersByQuestion(questionId: string): Observable<Answer[]> {
    return this.http.get<Answer[]>(`${this.apiUrl}answers/${questionId}`);
  }
}

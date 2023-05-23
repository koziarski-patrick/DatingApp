import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Survey } from 'src/app/_models/survey';
import { SurveyService } from 'src/app/_services/survey.service';

@Component({
  selector: 'app-survey-detail',
  templateUrl: './survey-detail.component.html',
  styleUrls: ['./survey-detail.component.css'],
})
export class SurveyDetailComponent implements OnInit {
  survey: Survey | undefined;

  constructor(
    private surveyService: SurveyService,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.loadSurvey();
  }

  loadSurvey() {
    this.route.params.subscribe({
      next: (params) => {
        const id = params['id'];
        if (id) {
          this.surveyService.getSurvey(id).subscribe({
            next: (survey: Survey) => {
              this.survey = survey;
              console.log('Survey retrieved:', this.survey);
            },
            error: (error) => {
              console.error('Error retrieving survey:', error);
            },
          });
        }
      },
      error: (error) => {
        console.error('Error retrieving route params:', error);
      },
    });
  }
}

import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Survey } from 'src/app/_models/survey';
import { SurveyService } from 'src/app/_services/survey.service';

@Component({
  selector: 'app-member-detail',
  templateUrl: './member-detail.component.html',
  styleUrls: ['./member-detail.component.css'],
})
export class MemberDetailComponent implements OnInit {
  survey: Survey | undefined;

  constructor(
    private surveyService: SurveyService,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {}

  loadSurvey() {
    this.route.params.subscribe(
      (params) => {
        const id = params['id'];
        if (id) {
          this.surveyService.getSurvey(id).subscribe(
            (survey) => {
              this.survey = survey;
              console.log('Survey retrieved:', this.survey);
            },
            (error) => {
              console.error('Failed to retrieve survey:', error);
            }
          );
        }
      },
      (error) => {
        console.error('Error retrieving route params:', error);
      }
    );
  }
}

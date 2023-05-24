import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Answer } from 'src/app/_models/answer';
import { Question } from 'src/app/_models/question';
import { Survey } from 'src/app/_models/survey';
import { SurveyService } from 'src/app/_services/survey.service';

@Component({
  selector: 'app-survey-detail',
  templateUrl: './survey-detail.component.html',
  styleUrls: ['./survey-detail.component.css'],
})
export class SurveyDetailComponent implements OnInit {
  survey: Survey | undefined;
  answers: Answer[] = [];
  questions: Question[] = [];

  constructor(
    private surveyService: SurveyService,
    private route: ActivatedRoute // private answerService: AnswerService
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
              this.getQuestions(id);
              // this.getAnswers(id);
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

  getQuestions(surveyId: string): void {
    this.surveyService
      .getQuestionsForSurvey(surveyId)
      .subscribe((questions: Question[]) => {
        this.questions = questions;
        console.log('Questions retrieved:', this.questions);
        // Iterate over the questions and get answers for each question
        this.questions.forEach((question: Question) => {
          this.getAnswers(question.questionID.toString());
        });
      });
  }

  // getAnswers(questionId: string): void {
  //   this.surveyService
  //     .getAnswersByQuestion(questionId)
  //     .subscribe((answers: Answer[]) => {
  //       this.answers = answers;
  //       console.log('Answers retrieved:', this.answers);
  //     });

  getAnswers(questionId: string): void {
    this.surveyService
      .getAnswersByQuestion(questionId)
      .subscribe((answers: Answer[]) => {
        this.questions.forEach((question) => {
          if (+question.questionID === +questionId) {
            question.answers = answers;
          }
        });
        console.log('Answers retrieved:', answers);
      });
  }

  // getAnswers(questionId: string): void {
  //   this.surveyService
  //     .getAnswersByQuestion(questionId)
  //     .subscribe((answers: Answer[]) => {
  //       this.answers.push(...answers);
  //       // console.log('Answers retrieved:', this.answers);
  //     });
  // }
}

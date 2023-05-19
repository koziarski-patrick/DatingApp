import { Component, OnInit } from '@angular/core';
import { LiveAnnouncer } from '@angular/cdk/a11y';
import { AfterViewInit, ViewChild } from '@angular/core';
import { MatSort, Sort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Survey } from 'src/app/_models/survey';
import { SurveyService } from 'src/app/_services/survey.service';
import { zip } from 'rxjs';


@Component({
  selector: 'app-member-list',
  templateUrl: './member-list.component.html',
  styleUrls: ['./member-list.component.css'],
})
export class MemberListComponent implements AfterViewInit, OnInit {
  displayedColumns: string[] = ['title', 'description', 'shareableURL'];

  surveys: Survey[] = []; // The surveys property is an array of Survey objects

  constructor(
    private _liveAnnouncer: LiveAnnouncer,
    private _surveyService: SurveyService
  ) {}

  ngOnInit(): void {
    // this.fetchSurveys(); // The fetchSurveys method is called when the component is initialized
  }

  dataSource: any;
  // fetchSurveys(): void {
  //   // The fetchSurveys method is used to retrieve the surveys from the API (via the SurveyService)
  //   this._surveyService.getSurveys().subscribe({
  //     next: (surveys) => {
  //       this.surveys = surveys;
  //       this.dataSource = new MatTableDataSource<Survey>(this.surveys);
  //       // this.dataSource.sort = this.sort;
  //       console.log('Surveys retrieved:', this.surveys); // The surveys are logged to the console
  //     },
  //     error: (error) => {
  //       console.error('Failed to retrieve surveys:', error);
  //     },
  //   });
  // }

  getShareableURL(survey: Survey): string {
    // The getShareableURL method is used to retrieve the shareable URL for a survey
    return survey.shareableURL;
  }


  @ViewChild(MatSort) sort!: MatSort;

  ngAfterViewInit(): void {
    zip(this._surveyService.getSurveys()).subscribe(([surveys]) => {
      this.surveys = surveys;
      this.dataSource = new MatTableDataSource(this.surveys);
      this.dataSource.sort = this.sort;
      console.log('Surveys retrieved:', this.surveys);
    });
  }

  /** Announce the change in sort state for assistive technology. */
  announceSortChange(sortState: Sort) {
    // This example uses English messages. If your application supports
    // multiple language, you would internationalize these strings.
    // Furthermore, you can customize the message to add additional
    // details about the values being sorted.
    if (sortState.direction) {
      this._liveAnnouncer.announce(`Sorted ${sortState.direction}ending`);
    } else {
      this._liveAnnouncer.announce('Sorting cleared');
    }
  }
}

import { Component } from '@angular/core';
import {LiveAnnouncer} from '@angular/cdk/a11y';
import {AfterViewInit, ViewChild} from '@angular/core';
import {MatSort, Sort} from '@angular/material/sort';
import {MatTableDataSource} from '@angular/material/table';

export interface PeriodicElement {
  name: string;
  position: number;
  weight: number;
  symbol: string;
  timeleft: number;
}
const ELEMENT_DATA: PeriodicElement[] = [
  {position: 1, name: 'Hydrogen', weight: 1.0079, symbol: 'H', timeleft: 10},
  {position: 2, name: 'Helium', weight: 4.0026, symbol: 'He', timeleft: 10},
  {position: 3, name: 'Lithium', weight: 6.941, symbol: 'Li', timeleft: 10},
  {position: 4, name: 'Beryllium', weight: 9.0122, symbol: 'Be', timeleft: 10},
  {position: 5, name: 'Boron', weight: 10.811, symbol: 'B', timeleft: 10},
  {position: 6, name: 'Carbon', weight: 12.0107, symbol: 'C', timeleft: 10},
  {position: 7, name: 'Nitrogen', weight: 14.0067, symbol: 'N', timeleft: 10},
  {position: 8, name: 'Oxygen', weight: 15.9994, symbol: 'O', timeleft: 10},
  {position: 9, name: 'Fluorine', weight: 18.9984, symbol: 'F', timeleft: 10},
  {position: 10, name: 'Neon', weight: 20.1797, symbol: 'Ne', timeleft: 10},
];
/**
 * @title Table with sorting
 */
@Component({
  selector: 'app-member-list',
  templateUrl: './member-list.component.html',
  styleUrls: ['./member-list.component.css']
})
export class MemberListComponent implements AfterViewInit {
  displayedColumns: string[] = ['position', 'name', 'weight', 'symbol', 'timeleft'];
  dataSource = new MatTableDataSource(ELEMENT_DATA);

  constructor(private _liveAnnouncer: LiveAnnouncer) {}

  @ViewChild(MatSort) sort!: MatSort;

  ngAfterViewInit() {
    this.dataSource.sort = this.sort;
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

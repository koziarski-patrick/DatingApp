import { Component, OnInit } from '@angular/core';
import { AccountService } from './_services/account.service';
import { User } from './_models/user';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent implements OnInit { // The AppComponent is the root component of the application (the root component is the first component that is loaded when the application starts)
  title = 'Dating App';

  constructor(private accountService: AccountService) {}

  ngOnInit(): void {
    this.setCurrentUser(); // This method is called when the application starts (to set the current user)
  }

    setCurrentUser() { // This method is used to set the current user
    const userString = localStorage.getItem('user'); // The user is stored in the local storage of the browser
    const user: User = userString !== null ? JSON.parse(userString) : null; // The user is retrieved from the local storage of the browser
    this.accountService.setCurrentUser(user); // The user is set as the current user
  }


}

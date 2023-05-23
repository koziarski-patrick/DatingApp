import { Component, OnInit } from '@angular/core';
import { AccountService } from '../_services/account.service';
import { Observable, of } from 'rxjs';
import { User } from '../_models/user';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css'],
})
export class NavComponent implements OnInit {
  model: any = {}; // The model property is used to store the username and password entered into the login form

  constructor(
    public accountService: AccountService,
    private router: Router,
    private toastr: ToastrService,
    private route: ActivatedRoute
  ) {} // The AccountService is injected into the constructor

  ngOnInit() {
    // The ngOnInit method is called when the component is initialized
  }

  login() {
    // The login method is called when the login button is clicked
    this.accountService.login(this.model).subscribe({
      next: () => {
        // The subscribe method is used to subscribe to the observable returned by the login method in the AccountService
        // this.router.navigate(['/members'], {relativeTo: this.route}); // The router is used to navigate to the members page
        this.router.navigateByUrl('/members'); // The router is used to navigate to the members page
      },
      error: (error) => {
        // The error method is called if there is an error returned from the API
        this.toastr.error(error.error); // The toastr service is used to display the error message returned from the API
      },
    });
  }

  logout() {
    // The logout method is called when the logout button is clicked
    this.accountService.logout(); // The logout method in the AccountService is called
    this.router.navigateByUrl('/'); // The router is used to navigate to the home page
  }
}

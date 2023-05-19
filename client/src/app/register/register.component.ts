import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { AccountService } from '../_services/account.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
})
export class RegisterComponent implements OnInit {
  @Output() cancelRegister = new EventEmitter(); // The cancelRegister property is used to pass data from the register component to the home component
  model: any = {}; // The model property is used to store the data of the register form

  constructor(private accountService: AccountService, private toastr: ToastrService) {}

  ngOnInit(): void {}

  register() { // This method is used to register a user (the user is registered by calling the register method of the account service)
    this.accountService.register(this.model).subscribe({
      next: () => {
        this.cancel(); // The cancel method is called if the user is successfully registered
      },
      error: (error) => {
        this.toastr.error(error.error); // The toastr service is used to display the error message returned from the API
      },
    });
  }

  cancel() {
    this.cancelRegister.emit(false); // The cancelRegister property is used to pass data from the register component to the home component
  }
}

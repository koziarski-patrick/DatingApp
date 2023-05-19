import { CanActivateFn } from '@angular/router';
import { AccountService } from '../_services/account.service';
import { inject } from '@angular/core';
import { map } from 'rxjs';
import { ToastrService } from 'ngx-toastr';

export const authGuard: CanActivateFn = () => {
  const current = inject(AccountService);
  const toastr = inject(ToastrService);
  return current._currentUser$.pipe(
    map((user) => {
      if (user) {
        return true;
      }
      toastr.error('This page is not accessible!');
      return false;
    })
  );
};

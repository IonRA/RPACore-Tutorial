import {Injectable} from '@angular/core';
import {Router, CanActivate} from '@angular/router';
import {UserService} from './UserService';
import {User} from '../model/user.model';

@Injectable()
export class AuthGuardService implements CanActivate {

  user: User;
  userServiceExch;

  constructor(public userService: UserService, public router: Router) {
    this.userServiceExch  = this.userService.execChange.subscribe((value) => {
      this.user = value;
    });
  }

  canActivate(): boolean {
    if (!this.user || !this.user.roles.includes('Admin')) {
      alert('You are unauthorized to access this page');
      this.router.navigate(['']);
      return false;
    }
    return true;
  }
}

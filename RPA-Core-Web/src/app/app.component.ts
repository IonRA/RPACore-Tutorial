import {Component, ViewChild} from '@angular/core';
import {Router} from '@angular/router';
import {LoginComponent} from './login/login.component';
import {UserService} from '../service/UserService';
import {User} from '../model/user.model';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  isLogged = false;

  loggedUser: User;
  subscriptionUser;

  constructor(private router: Router,
              private userService: UserService) {
    this.subscriptionUser = this.userService.execChange.subscribe((value) => {
      this.loggedUser = value;
      this.isLogged = true;
    });
  }

  logout() {
    this.userService.userChange(null);
    this.isLogged = false;
    this.router.navigate(['/login']);
  }
}

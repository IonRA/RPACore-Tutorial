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

  constructor(private router: Router,
              private userService: UserService) {
    const storageUserString = sessionStorage.getItem('user');
    if (!!storageUserString) {
      const storageUser: User = JSON.parse(storageUserString);
      this.loggedUser = storageUser;
      this.isLogged = true;
      this.userService.userChange(storageUser);
    }

    this.userService.execChange.subscribe((value) => {
      if (!!value) {
        this.loggedUser = value;
        this.isLogged = true;
        sessionStorage.setItem('user', JSON.stringify(value));
      }
    });
  }

  logout() {
    this.userService.userChange(null);
    this.isLogged = false;
    this.router.navigate(['/login']);
  }
}

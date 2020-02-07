import {Component, EventEmitter, OnInit, Output} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Router} from '@angular/router';
import {UserService} from '../../service/UserService';
import {User} from '../../model/user.model';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(private httpClient: HttpClient,
              private router: Router,
              private userService: UserService) {
  }

  username: string;
  password: string;
  showSpinner = false;

  ngOnInit() {
  }

  login(): void {
    this.showSpinner = true;
    const credentials = {
      email: this.username,
      password: this.password,
      rememberMe: false,
    };
    // TODO httpClient interceptor
    this.httpClient.post<User>('https://localhost:44305/api/User', credentials)
      .toPromise()
      .then(response => {
        this.userService.userChange(response);
        this.router.navigate(['']);
      })
      .catch(ex => {
        alert(ex.error);
        this.showSpinner = false;
      });
  }
}


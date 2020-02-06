import {Component, EventEmitter, OnInit, Output} from '@angular/core';
import {HttpClient} from '@angular/common/http';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  @Output()
  loginComplete = new EventEmitter();

  constructor(private httpClient: HttpClient) {
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
    this.httpClient.post('https://localhost:44305/api/User', credentials)
      .subscribe(response => {
        console.log(response);
      });
    this.loginComplete.emit({
      username: this.username
    });
  }
}


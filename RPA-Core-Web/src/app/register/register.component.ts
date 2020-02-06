import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {HttpClient} from '@angular/common/http';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  @Output()
  registerComplete = new EventEmitter();

  username: string;
  password: string;
  confirmPassword: string;
  showSpinner = false;

  constructor(private httpClient: HttpClient) {
  }

  ngOnInit() {
  }

  register() {
    this.showSpinner = true;
    const credentials = {
      email: this.username,
      password: this.password,
      confirmPassword: this.confirmPassword,
    };
    this.httpClient.post('https://localhost:44305/api/User/register', credentials)
      .subscribe(response => {
        console.log(response);
      });
    this.registerComplete.emit();
  }
}

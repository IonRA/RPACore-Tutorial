import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Router} from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  username: string;
  password: string;
  confirmPassword: string;
  showSpinner = false;

  constructor(private httpClient: HttpClient,
              private router: Router) {
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
      .toPromise()
      .then(response => {
        this.router.navigate(['/login']);
      })
      .catch(ex => {
        if (!!ex.error.errors) {
          Object.values(ex.error.errors).forEach((err: Array<string>, i) => {
            err.forEach(errMessage => {
              alert(errMessage);
            });
          });
        } else {
          ex.error.forEach(err => {
            alert(err.description);
          });
        }
        this.showSpinner = false;
      });
  }

}

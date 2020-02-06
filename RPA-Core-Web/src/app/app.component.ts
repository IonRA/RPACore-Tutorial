import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  isLogged = false;
  username: string;
  toggleRegister = false;

  onRegisterComplete() {
    this.toggleRegister = false;
  }

  onLoginComplete(event) {
    this.isLogged = true;
    this.username = event.username;
  }

  logout() {
    this.username = null;
    this.isLogged = false;
  }
}

import {Component, OnInit} from '@angular/core';
import {ActivatedRoute, Router} from '@angular/router';
import {HttpClient} from '@angular/common/http';
import {UserRole} from '../../model/user-role.model';

@Component({
  selector: 'app-user-role-edit',
  templateUrl: './user-role-edit.component.html',
  styleUrls: ['./user-role-edit.component.css']
})
export class UserRoleEditComponent implements OnInit {

  roleName: string;
  users: Array<UserRole>;
  showSpinner = false;

  constructor(private route: ActivatedRoute,
              private router: Router,
              private httpClient: HttpClient) {
    this.route.params.subscribe(params => {
      this.roleName = params.roleName;
    });
  }

  ngOnInit() {
    this.httpClient.get<Array<UserRole>>(`https://localhost:44305/api/Administration/users?roleName=${this.roleName}`)
      .subscribe(result => this.users = result);
  }

  save() {
    this.httpClient.post(`https://localhost:44305/api/Administration/users?roleName=${this.roleName}`, this.users)
      .toPromise()
      .then(() => {
        this.router.navigate(['/admin']);
      })
      .catch(ex => {
        alert(ex.error);
        this.showSpinner = false;
      });
  }
}

import { Component, OnInit } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Role} from '../../model/role.model';
import {Router} from '@angular/router';

@Component({
  selector: 'app-admin-interface',
  templateUrl: './admin-interface.component.html',
  styleUrls: ['./admin-interface.component.css']
})
export class AdminInterfaceComponent implements OnInit {

  roles: Array<Role>;

  constructor(private httpClient: HttpClient,
              private router: Router) { }

  ngOnInit() {
    this.httpClient.get<Array<Role>>('https://localhost:44305/api/Administration')
      .subscribe(result => this.roles = result);
  }

}

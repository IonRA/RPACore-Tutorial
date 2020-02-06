import { Component, OnInit } from '@angular/core';
import {HttpClient} from '@angular/common/http';

@Component({
  selector: 'app-admin-interface',
  templateUrl: './admin-interface.component.html',
  styleUrls: ['./admin-interface.component.css']
})
export class AdminInterfaceComponent implements OnInit {

  roles: Array<any>;

  constructor(private httpClient: HttpClient) { }

  ngOnInit() {
    this.httpClient.get<Array<any>>('https://localhost:44305/api/Administration')
      .subscribe(result => {
        this.roles = result;
        console.log(this.roles);
      });
  }

}

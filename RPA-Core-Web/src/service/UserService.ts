import {Injectable} from '@angular/core';
import {Subject} from 'rxjs';
import {User} from '../model/user.model';

@Injectable()
export class UserService {

  execChange: Subject<User> = new Subject<User>();

  constructor() {
  }

  userChange(data: User) {
    this.execChange.next(data);
  }

}

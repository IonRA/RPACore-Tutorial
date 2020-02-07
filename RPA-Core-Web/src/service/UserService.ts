import {Injectable} from '@angular/core';
import {BehaviorSubject} from 'rxjs';
import {User} from '../model/user.model';

@Injectable()
export class UserService {

  execChange: BehaviorSubject<User> = new BehaviorSubject <User>(null);

  constructor() {
  }

  userChange(data: User) {
    this.execChange.next(data);
  }

}

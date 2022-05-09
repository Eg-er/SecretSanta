import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html'
})
export class UsersComponent {
  public users: User[] = [];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<User[]>(baseUrl + 'home').subscribe(result => {
      this.users = result;
      for(let x = 0;x<this.users.length;x++){
        let receiver = this.users.filter(e => e.id === this.users[x].receiverId)[0];
        this.users[x].receiverName = receiver.name;
        this.users[x].receiverSurname = receiver.surname;
      }
    }, error => console.error(error));
  }
}

interface User {
  id: number;
  name: string;
  surname: string;
  receiverId: number;
  receiverName: string;
  receiverSurname: string;
}

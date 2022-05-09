import {Component, Inject, OnInit} from '@angular/core';
import {FormControl, FormGroup, Validators} from "@angular/forms";
import {HttpClient, HttpHeaders} from "@angular/common/http";

@Component({
  selector: 'app-add-user',
  templateUrl: './add-user.component.html',
})
export class AddUserComponent implements OnInit{
  formdata!: FormGroup;
  http: HttpClient;
  baseUrl: string;

  ngOnInit() {
   this.formdata = new FormGroup({
     name: new FormControl('',[Validators.required, Validators.pattern('[a-zA-Z]{1,}')]),
     surname: new FormControl('',[Validators.required,Validators.pattern('[a-zA-Z]{1,}')])
   });
  }

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.http = http
    this.baseUrl = baseUrl;
  }

  onClickSubmit(data: FormGroup) {
    const headers= new HttpHeaders()
      .set('content-type', 'application/json');
    this.http.post(this.baseUrl+'home', JSON.stringify(data),{'headers':headers}).subscribe(result => {
      alert("Created!");
      this.formdata.reset();
    }, error => {
    let errors = error.error.errors;
    let res = "";
    Object.entries(errors).forEach(([key, value]) => res+=value+"\n");
    alert(res);
    });
  }
}


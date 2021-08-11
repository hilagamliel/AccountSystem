import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Personal } from '../Classes/Personal';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { PersonalWithType } from '../Classes/PersonalWithType';

@Component({
  selector: 'app-form-personal',
  templateUrl: './form-personal.component.html',
  styleUrls: ['./form-personal.component.css']
})
export class FormPersonalComponent implements OnInit {

  @Input() IdType: number;
  @Input() IfAddPersonal: boolean;
  @Output() AddPersonal = new EventEmitter<PersonalWithType>();

  constructor() { }
  myForm: FormGroup = new FormGroup({
    tz: new FormControl("", [Validators.required, Validators.pattern('[0-9]*'),
    Validators.minLength(9), Validators.maxLength(9)]),
    name: new FormControl("", Validators.required),
    address: new FormControl("", Validators.required),
    email: new FormControl("", [Validators.email, Validators.required]),
    phoneNumber: new FormControl("", [Validators.required,Validators.pattern('0[0-9]*'),
    Validators.minLength(10), Validators.maxLength(10)])
  });

  ngOnInit(): void {
  }
  SubmitAdd() {
    let per: PersonalWithType;
    per = new PersonalWithType(this.myForm.value.tz, this.myForm.value.name,
      this.myForm.value.address, this.myForm.value.email, this.myForm.value.phoneNumber, this.IdType);
    this.AddPersonal.emit(per);
  }
}

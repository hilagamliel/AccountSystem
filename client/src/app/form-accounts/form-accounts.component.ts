import { Component, OnInit } from '@angular/core';
import { AccountWithPersonal } from '../Classes/AccountWithPersonal';
import { PersonalWithType } from '../Classes/PersonalWithType';
import { Account } from '../Classes/Account';
import { ManagerService } from '../services/manager.service';
import { async } from '@angular/core/testing';

@Component({
  selector: 'app-form-accounts',
  templateUrl: './form-accounts.component.html',
  styleUrls: ['./form-accounts.component.css']
})
export class FormAccountsComponent implements OnInit {

  constructor(private Manager:ManagerService) { }

  countAccount: number = 1;
  countsPersonals = [1, 1, 1];
  ifAddAccount: boolean = false;


  Accounts: AccountWithPersonal[] = [];

  ngOnInit(): void {
  }
  AddPersonal(Personal: PersonalWithType) {
    if (!this.Accounts[this.countAccount - 1])
      this.Accounts[this.countAccount - 1] = new AccountWithPersonal();
    this.Accounts[this.countAccount - 1].PersonalsWithType.push(Personal);
    this.countsPersonals[(Personal.IdType - 1)]++;
    if (Personal.IdType == 1)
      this.ifAddAccount = true;
  }
  AddAccount(account: Account) {
    this.Accounts[this.countAccount - 1].Account = account;
    this.countAccount++;
    this.countsPersonals.fill(1);
    this.ifAddAccount = false;
  }
  Send(){
    this.Accounts.forEach(async(a)=>await this.Manager.AddAccountWithPersonals(a));
  }
}

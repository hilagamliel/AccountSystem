import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Account } from '../Classes/Account'
import { InvestmentPolicyTypes } from '../Classes/InvestmentPolicyTypes';
import { InvestmentPolicyTypesService } from '../services/investment-policy-types.service';
@Component({
  selector: 'app-form-account',
  templateUrl: './form-account.component.html',
  styleUrls: ['./form-account.component.css']
})
export class FormAccountComponent implements OnInit {

  constructor(private investmentPolicyTypesService: InvestmentPolicyTypesService) { }
  account: Account;
  InvestmentPolicyTypes: InvestmentPolicyTypes[] = [];

  @Input() IfAddAccount: boolean;
  @Output() AddAccount = new EventEmitter<Account>();

  ngOnInit(): void {
    this.investmentPolicyTypesService.getInvestmentPolicyTypes().subscribe(data => this.InvestmentPolicyTypes = data);
    this.account = new Account();
  }
  SubmitAdd() {
    this.AddAccount.emit(Object.assign({},this.account));
  }

}

import { Injectable } from '@angular/core';
import { AccountService } from './account.service';
import { PersonalService } from './personal.service';
import { PersonalInAccountService } from './personal-in-account.service';
import { AccountWithPersonal } from '../Classes/AccountWithPersonal';
import { Account } from '../Classes/Account';


@Injectable({
  providedIn: 'root'
})
export class ManagerService {

  constructor(private accountService:AccountService,private PersonalService:PersonalService,
    private PersonalInAccount:PersonalInAccountService) { }

    AddAccountWithPersonals(AccountWithPersonals:AccountWithPersonal){
      this.accountService.AddAccount(AccountWithPersonals.Account).subscribe((data)=>{

       AccountWithPersonals.PersonalsWithType.forEach((p)=>{
         this.PersonalService.AddPersonal(this.PersonalService.CastToPersonal(p)).subscribe();
        });
        setTimeout(()=>{
        AccountWithPersonals.Account.Id=parseInt(data.id);
        this.PersonalInAccount.AddPersonalsInAccount(AccountWithPersonals);},20);
      });
      
    }
}

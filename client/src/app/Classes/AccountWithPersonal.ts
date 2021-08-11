import { Account } from './Account';
import { PersonalWithType}from './PersonalWithType'
export class AccountWithPersonal {
    Account:Account;
    PersonalsWithType:PersonalWithType[];
    constructor(){
            this.PersonalsWithType=[];
    }
}

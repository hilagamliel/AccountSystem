import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpResponse, HttpRequest } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { retry, catchError, map } from 'rxjs/operators';
import { AccountWithPersonal } from '../Classes/AccountWithPersonal';

@Injectable({
  providedIn: 'root'
})
export class PersonalInAccountService {

  api = "https:localhost:44353/api/PersonalInAccount";

  constructor(private httpClient: HttpClient) { }

  AddPersonalsInAccount(accountWithPersonal: AccountWithPersonal) {
    accountWithPersonal.PersonalsWithType.forEach((p) => {
      let per = { "Id": 0, "IdAccount":accountWithPersonal.Account.Id, "TzPersonal": p.Tz, "IdPersonalTypes":  p.IdType };
      this.AddPersonalInAccount(per).subscribe();
    })
  }
  AddPersonalInAccount(per: any): Observable<any> {
    return this.httpClient.post<any[]>(this.api, per);
  }
}

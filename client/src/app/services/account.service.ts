import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders,HttpResponse,HttpRequest } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { retry, catchError, map } from 'rxjs/operators';
@Injectable({
  providedIn: 'root'
})
export class AccountService {

  api="https://localhost:44353/api/Account";

  constructor(private httpClient:HttpClient ) { }
  
  AddAccount(account: any):Observable<Account> {
    account.id='0'; 
    return this.httpClient.post<any>(this.api,account);
 }
}

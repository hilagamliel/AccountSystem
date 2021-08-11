import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders,HttpResponse,HttpRequest } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { retry, catchError, map } from 'rxjs/operators';
import { InvestmentPolicyTypes } from '../Classes/InvestmentPolicyTypes';


@Injectable({
  providedIn: 'root'
})
export class InvestmentPolicyTypesService {

  constructor(private httpClient: HttpClient) { }
  api="https:localhost:44353/api/InvestmentPolicyTypes";

  getInvestmentPolicyTypes(): Observable<InvestmentPolicyTypes[]> {
    return this.httpClient.get<InvestmentPolicyTypes[]>(this.api);
  }
}

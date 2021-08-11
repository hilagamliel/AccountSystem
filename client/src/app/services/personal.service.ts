import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpResponse, HttpRequest } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { retry, catchError, map } from 'rxjs/operators';
import { PersonalWithType } from '../Classes/PersonalWithType';
import { Personal } from '../Classes/Personal';

@Injectable({
  providedIn: 'root'
})
export class PersonalService {

  api = "https://localhost:44353/api/Personal";
  Per=new Personal();
  constructor(private httpClient: HttpClient) { }

  AddPersonal(Personal: any): Observable<Personal> {
    return this.httpClient.post<any>(this.api, Personal);
  }
  CastToPersonal(Personal: PersonalWithType) {
    this.Per.Tz=Personal.Tz;
    this.Per.Phone=Personal.Phone;
    this.Per.Name=Personal.Name;
    this.Per.Email=Personal.Email;
    this.Per.Address=Personal.Address;
    return this.Per;
  }
}

import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Router } from '@angular/router';
import { CustomHttpService } from './custom-http.service';
import { CookieService } from "ngx-cookie-service"
import { LoginService } from './login.service';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { RoleEnum } from '../models/RoleEnum';
import { url } from '../congif';
import Failure from '../models/Failure';



@Injectable()
export class FailureService {

  constructor(
    private httpService: CustomHttpService,
    private router: Router,
    private cookieService: CookieService,
    private loginService: LoginService,
    private http: HttpClient
  ) { }


  protected getToken() {
    return this.cookieService.get('te_token')
  }

  getAuthHeader() {
    return new HttpHeaders({ 'Authorization': 'Bearer ' + this.getToken })
  }

  getVehicles() {
    // return this.httpService
    //   .post(`${url}/failures`)
    //   .toPromise()
    //   .then((response: Response) => {
    //     const tokenModel = response.json()
    //     return tokenModel
    //   })
    //   .catch(error => {
    //     console.error(error)
    //   })
    return new Promise((resolve, reject) => {
      resolve([
        {
          id: 1,
          firstName: "Imie1",
          lastName: "Nazwisko1",
          login: "login1",
          role: RoleEnum.ADMIN,
        },
        {
          id: 2,
          firstName: "Imie2",
          lastName: "Nazwisko2",
          login: "login2",
          role: RoleEnum.DRIVER,
        }
      ])
    })
  }

  getOne(id: number) {
    return this.http
      .get(`${url}/failures/${id}`, { headers: this.getAuthHeader() })
      .toPromise()
      .then((response: Response) => {
        const failure = response.json()
        return failure
      })
      .catch(error => {
        console.error(error)
      })
  }

  add(failure: Failure) {
    return this.http
      .post(`${url}/failures`, failure, { headers: this.getAuthHeader() })
      .toPromise()
      .then((response: Response) => {
        const failure = response.json()
        return failure
      })
      .catch(error => {
        console.error(error)
      })
  }

  update(id: number, failure: Failure) {
    return this.http
      .put(`${url}/failures/${id}`, failure, { headers: this.getAuthHeader() })
      .toPromise()
      .then((response: Response) => {
        const failure = response.json()
        return failure
      })
      .catch(error => {
        console.error(error)
      })
  }

  delete(id: number) {
    return this.http
      .delete(`${url}/failure/${id}`, { headers: this.getAuthHeader() })
      .toPromise()
      .then((response: Response) => {
        const failure = response.json()
        return failure
      })
      .catch(error => {
        console.error(error)
      })
  }
}
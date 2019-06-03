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

  get() {
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
          vehicleId: 2,
          description: "To jest opis",
          repaired: false,
          notificationDate: new Date(),
          acceptedForRepair: false,
          endOfRepairDate: null,
          plannedEndOfRepairDate: null
        },
        {
          id: 2,
          vehicleId: 5,
          description: "To jest opis ale troche inny",
          repaired: false,
          notificationDate: new Date(),
          acceptedForRepair: true,
          endOfRepairDate: null,
          plannedEndOfRepairDate: new Date()
        },
        {
          id: 3,
          vehicleId: 8,
          description: "To jest opis ale troche jeszcze bardziej inny",
          repaired: true,
          notificationDate: new Date(),
          acceptedForRepair: true,
          endOfRepairDate: new Date(),
          plannedEndOfRepairDate: new Date()
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
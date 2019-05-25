import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Router } from '@angular/router';
import { HttpClient } from 'selenium-webdriver/http';
import { CustomHttpService } from './custom-http.service';
import { CookieService } from "ngx-cookie-service"



@Injectable()
export class UserService {

  constructor(
    private httpService: CustomHttpService,
    private router: Router,
    private cookieService: CookieService
  ) { }


  protected getToken() {
    return this.cookieService.get('te_token')
  }

  getUsers() {
    // return this.httpService
    //   .post('/token', { login: login, password: password })
    //   .toPromise()
    //   .then((response: Response) => {
    //     const tokenModel = response.json()
    //     return tokenModel
    //   })
    //   .catch(error => {
    //     console.error(error)
    //   })
    return new Promise((resolve, reject) => {
      resolve({ role: "admin" })
    })
  }

  getUser(id: string) {
    // return this.httpService
    //   .post('/token', { login: login, password: password })
    //   .toPromise()
    //   .then((response: Response) => {
    //     const tokenModel = response.json()
    //     return tokenModel
    //   })
    //   .catch(error => {
    //     console.error(error)
    //   })
    return new Promise((resolve, reject) => {
      resolve({ role: "admin" })
    })
  }

  addUser(id: string) {

  }

  updateUser(id: string) {

  }

  deleteUser(id: string) {

  }
}
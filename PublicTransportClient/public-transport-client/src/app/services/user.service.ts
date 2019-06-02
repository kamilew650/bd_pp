import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Router } from '@angular/router';
import { CustomHttpService } from './custom-http.service';
import { CookieService } from "ngx-cookie-service"
import { LoginService } from './login.service';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { RoleEnum } from '../models/RoleEnum';
import User from '../models/User';



@Injectable()
export class UserService {

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

  getUser(id: number) {
    return this.http
      .get(`/token/${id}`, { headers: this.getAuthHeader() })
      .toPromise()
      .then((response: Response) => {
        const user = response.json()
        return user
      })
      .catch(error => {
        console.error(error)
      })
  }

  addUser(user: User) {
    return this.http
      .post('/token', user, { headers: this.getAuthHeader() })
      .toPromise()
      .then((response: Response) => {
        const user = response.json()
        return user
      })
      .catch(error => {
        console.error(error)
      })
  }

  updateUser(id: number, user: User) {
    return this.http
      .put(`/token/${id}`, user, { headers: this.getAuthHeader() })
      .toPromise()
      .then((response: Response) => {
        const user = response.json()
        return user
      })
      .catch(error => {
        console.error(error)
      })
  }

  deleteUser(id: number) {
    return this.http
      .delete(`/token/${id}`, { headers: this.getAuthHeader() })
      .toPromise()
      .then((response: Response) => {
        const user = response.json()
        return user
      })
      .catch(error => {
        console.error(error)
      })
  }
}
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Router } from '@angular/router';
import { CustomHttpService } from './custom-http.service';
import { CookieService } from "ngx-cookie-service"
import { LoginService } from './login.service';
import { HttpHeaders, HttpClient } from '@angular/common/http';



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
      resolve({ role: "admin" })
    })
  }

  getUser(id: string) {
    return this.http
      .post('/token', { id: id }, { headers: this.getAuthHeader() })
      .toPromise()
      .then((response: Response) => {
        const user = response.json()
        return user
      })
      .catch(error => {
        console.error(error)
      })
  }

  addUser(id: string) {
    // return this.httpService
    //   .post('/token', {id: id},)
    //   .toPromise()
    //   .then((response: Response) => {
    //     const tokenModel = response.json()
    //     return tokenModel
    //   })
    //   .catch(error => {
    //     console.error(error)
    //   })
  }

  updateUser(id: string) {
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
  }

  deleteUser(id: string) {
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
  }
}
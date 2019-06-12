import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Router } from '@angular/router';
import { HttpClient } from 'selenium-webdriver/http';
import { CustomHttpService } from './custom-http.service';
import { CookieService } from "ngx-cookie-service"
import { url } from '../congif';




@Injectable()
export class LoginService {

  loggedUser
  tokenModel

  get token() {
    if (this.cookieService.get('te_token')) {
      return this.cookieService.get('te_token')
    } else {
      this.router.navigate(['/login'])
    }
  }

  get isLoggedIn() {
    return this.token ? true : false
  }

  constructor(
    private httpService: CustomHttpService,
    private router: Router,
    private cookieService: CookieService
  ) { }


  protected getToken() {
    return this.cookieService.get('te_token')
  }

  login(login: string, password: string) {
    return this.httpService
      .post(`${url}user/authenticate`, { login: login, password: password })
      .toPromise()
    // return new Promise((resolve, reject) => {
    //   resolve({ role: "admin" })
    // })
  }

  logout() {
    this.tokenModel = null
    this.cookieService.deleteAll()
  }
}
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Router } from '@angular/router';
import { HttpClient } from 'selenium-webdriver/http';
import { CustomHttpService } from './custom-http.service';
import { CookieService } from "ngx-cookie-service"



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

  // private handleUserChanged(tokenModel: TokenModel) {
  //   this.loggedUser.next(tokenModel)
  // }

  constructor(
    private httpService: CustomHttpService,
    private router: Router,
    private cookieService: CookieService
  ) { }


  protected getToken() {
    return this.cookieService.get('te_token')
  }

  login(login: string, password: string) {
    // return this.httpService
    //   .post('/token', { login: login, password: password })
    //   .toPromise()
    //   .map((response: Response) => {
    //     const tokenModel = response.json()
    //     this.handleUserChanged(tokenModel)
    //     return tokenModel
    //   })
    //   .catch(error => {
    //     if (error.status == 500 || error.status == 0 || !error.json)
    //       return Observable.throw({
    //         error: 'Błąd serwera. Spróbuj ponownie później.'
    //       })
    //     else return Observable.throw(error.json())
    //   })
  }
}
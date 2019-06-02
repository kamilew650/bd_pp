import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Router } from '@angular/router';
import { CustomHttpService } from './custom-http.service';
import { CookieService } from "ngx-cookie-service"
import { LoginService } from './login.service';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { RoleEnum } from '../models/RoleEnum';
import { url } from '../congif';
import Vehicle from '../models/Vehicle';



@Injectable()
export class TechnicalReviewService {

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
    //   .post(`${url}/technicalReviews`)
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
      .get(`${url}/technicalReviews/${id}`, { headers: this.getAuthHeader() })
      .toPromise()
      .then((response: Response) => {
        const review = response.json()
        return review
      })
      .catch(error => {
        console.error(error)
      })
  }

  add(review: Vehicle) {
    return this.http
      .post(`${url}/technicalReviews`, review, { headers: this.getAuthHeader() })
      .toPromise()
      .then((response: Response) => {
        const review = response.json()
        return review
      })
      .catch(error => {
        console.error(error)
      })
  }

  update(id: number, review: Vehicle) {
    return this.http
      .put(`${url}/technicalReviews/${id}`, review, { headers: this.getAuthHeader() })
      .toPromise()
      .then((response: Response) => {
        const review = response.json()
        return review
      })
      .catch(error => {
        console.error(error)
      })
  }

  delete(id: number) {
    return this.http
      .delete(`${url}/technicalReviews/${id}`, { headers: this.getAuthHeader() })
      .toPromise()
      .then((response: Response) => {
        const review = response.json()
        return review
      })
      .catch(error => {
        console.error(error)
      })
  }
}
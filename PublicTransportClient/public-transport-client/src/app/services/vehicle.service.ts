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
export class VehicleService {

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
    //   .post(`${url}/vehicle`)
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
          brand: "Marka1",
          model: "Model1",
          yearOfProduction: 2001,
          mileage: 1000,
          purchaseDate: new Date(),
          available: true,
          seats: 12,
        },
        {
          id: 2,
          brand: "Marka2",
          model: "Model2",
          yearOfProduction: 2001,
          mileage: 1023,
          purchaseDate: new Date(),
          available: false,
          seats: 12,
        }
      ])
    })
  }

  getOne(id: number) {
    return this.http
      .get(`${url}/vehicles/${id}`, { headers: this.getAuthHeader() })
      .toPromise()
      .then((response: Response) => {
        const vehicle = response.json()
        return vehicle
      })
      .catch(error => {
        console.error(error)
      })
  }

  add(vehicle: Vehicle) {
    return this.http
      .post(`${url}/vehicles`, vehicle, { headers: this.getAuthHeader() })
      .toPromise()
      .then((response: Response) => {
        const vehicle = response.json()
        return vehicle
      })
      .catch(error => {
        console.error(error)
      })
  }

  update(id: number, vehicle: Vehicle) {
    return this.http
      .put(`${url}/vehicles/${id}`, vehicle, { headers: this.getAuthHeader() })
      .toPromise()
      .then((response: Response) => {
        const vehicle = response.json()
        return vehicle
      })
      .catch(error => {
        console.error(error)
      })
  }

  delete(id: number) {
    return this.http
      .delete(`${url}/vehicles/${id}`, { headers: this.getAuthHeader() })
      .toPromise()
      .then((response: Response) => {
        const vehicle = response.json()
        return vehicle
      })
      .catch(error => {
        console.error(error)
      })
  }
}
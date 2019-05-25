import { Component, OnInit } from '@angular/core';
import { NgForm, NgModel } from '@angular/forms';
import { LoginService } from '../services/login.service';
import UserModel from '../models/UserModel';
import { Router, ActivatedRoute } from '@angular/router';
import { isError } from 'util';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  login: string
  password: string
  isError: boolean = false

  constructor(
    private loginService: LoginService,
    private readonly router: Router,
    private readonly route: ActivatedRoute,
  ) { }

  ngOnInit() {
    this.clean
  }

  clean() {
    this.login = null
    this.password = null
  }


  tryLogin() {
    console.log(this.password, this.login)
    this.loginService.login(this.login, this.password).then(res => {
      const user = res as UserModel
      console.log("co")
      switch (user.role) {
        case 'admin':
          this.router.navigateByUrl('/admin');
          break
        case 'driver':
          this.router.navigateByUrl('/driver');
          break
        default:
          this.isError = true

      }

    })
      .catch(err => {
        console.error(err)
      })
  }

}

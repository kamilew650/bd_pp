import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { FormsModule } from '@angular/forms';
import { AdminModule } from './admin/admin.module';
import { HttpClientModule } from '@angular/common/http';
import { DriverModule } from './driver/driver.module';
import { LoginService } from './services/login.service';
import { CustomHttpService } from './services/custom-http.service';
import { CookieService } from 'ngx-cookie-service';
import { ManagerModule } from './manager/manager.module';
import { PlannerModule } from './planner/planner.module';
import { SetterModule } from './setter/setter.module';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    AdminModule,
    NgbModule,
    HttpClientModule,
    DriverModule,
    ManagerModule,
    PlannerModule,
    SetterModule
  ],
  providers: [LoginService, CustomHttpService, CookieService],
  bootstrap: [AppComponent]
})
export class AppModule { }

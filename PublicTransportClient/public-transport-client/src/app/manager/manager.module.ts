import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ManagerComponent } from './manager.component';
import { NavbarComponent } from './navbar/navbar.component';
import { ManagerRoutingModule } from './manager.routing';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { SurveyComponent } from './survey/survey.component';
import { FailureComponent } from './failure/failure.component';
import { VahicleComponent } from './vahicle/vahicle.component';

@NgModule({
  declarations: [ManagerComponent, NavbarComponent, SurveyComponent, FailureComponent, VahicleComponent],
  imports: [
    CommonModule,
    ManagerRoutingModule,
    NgbModule
  ]
})
export class ManagerModule { }

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PlannerComponent } from './planner.component';
import { NavbarComponent } from './navbar/navbar.component';
import { PlannerRoutingModule } from './planner.routing';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

@NgModule({
  declarations: [PlannerComponent, NavbarComponent],
  imports: [
    CommonModule,
    PlannerRoutingModule,
    NgbModule
  ]
})
export class PlannerModule { }

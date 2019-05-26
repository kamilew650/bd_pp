import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ManagerComponent } from './manager.component';
import { NavbarComponent } from './navbar/navbar.component';
import { ManagerRoutingModule } from './manager.routing';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

@NgModule({
  declarations: [ManagerComponent, NavbarComponent],
  imports: [
    CommonModule,
    ManagerRoutingModule,
    NgbModule
  ]
})
export class ManagerModule { }

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavbarComponent } from './navbar/navbar.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { AdminComponent } from '../admin/admin.component';
import { AdminRoutingModule } from '../admin/admin.routing';

@NgModule({
  declarations: [AdminComponent, NavbarComponent],
  imports: [
    CommonModule,
    AdminRoutingModule,
    NgbModule
  ]
})
export class DriverModule { }

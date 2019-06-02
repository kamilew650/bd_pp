import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ManagerComponent } from './manager.component';
import { NavbarComponent } from './navbar/navbar.component';


export const routes: Routes = [
  {
    path: '',
    component: ManagerComponent,
    data: {
      breadcrumb: [null]
    },
    children: [
      {
        path: '',
        component: NavbarComponent
      }
    ],
  }
]


@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ManagerRoutingModule { }

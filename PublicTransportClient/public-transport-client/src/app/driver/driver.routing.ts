import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { DriverComponent } from './driver.component';


export const routes: Routes = [
  {
    path: '',
    component: DriverComponent,
    data: {
      breadcrumb: [null]
    },
    children: [
      {
      }
    ],
  }
]


@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class DriverRoutingModule { }

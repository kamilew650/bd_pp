import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { DriverComponent } from './driver.component';
import { VehiclesComponent } from './vehicles/vehicles.component';


export const routes: Routes = [
  {
    path: '',
    component: DriverComponent,
    data: {
      breadcrumb: [null]
    },
    children: [
      {
        path: '',
        component: VehiclesComponent
      }
    ],
  }
]


@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class DriverRoutingModule { }

import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AdminComponent } from './admin.component';


export const routes: Routes = [
  {
    path: '',
    component: AdminComponent,
    data: {
      breadcrumb: [null]
    },
    children: [
    ],
  }
]


@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminRoutingModule { }

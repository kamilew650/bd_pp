import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ManagerComponent } from './manager.component';
import { NavbarComponent } from './navbar/navbar.component';
import { SurveyComponent } from './survey/survey.component';


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
        component: SurveyComponent
      }
    ],
  }
]


@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ManagerRoutingModule { }

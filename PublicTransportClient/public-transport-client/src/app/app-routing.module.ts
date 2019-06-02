import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { AdminModule } from './admin/admin.module';
import { DriverModule } from './driver/driver.module';
import { PlannerModule } from './planner/planner.module';
import { SetterModule } from './setter/setter.module';
import { ManagerModule } from './manager/manager.module';

export const routes: Routes = [
  {
    path: '',
    component: HomeComponent
  },
  {
    path: 'admin',
    loadChildren: () => AdminModule
  },
  {
    path: 'driver',
    loadChildren: () => DriverModule
  },
  {
    path: 'planner',
    loadChildren: () => PlannerModule
  },
  {
    path: 'setter',
    loadChildren: () => SetterModule
  },
  {
    path: 'manager',
    loadChildren: () => ManagerModule
  }
]

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

import { NgModule } from '@angular/core';
import { SharedModule } from '../shared/shared.module';

import { DepartmentRoutingModule } from './department-routing.module';
import { DepartmentComponent } from './department.component';


@NgModule({
  declarations: [
    DepartmentComponent
  ],
  imports: [
    SharedModule,
    DepartmentRoutingModule
  ]
})
export class DepartmentModule { }

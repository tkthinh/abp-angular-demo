import { NgModule } from '@angular/core';
import { SharedModule } from '../shared/shared.module';

import { StaffRoutingModule } from './staff-routing.module';
import { StaffComponent } from './staff.component';


@NgModule({
  declarations: [
    StaffComponent
  ],
  imports: [
    SharedModule,
    StaffRoutingModule
  ]
})
export class StaffModule { }

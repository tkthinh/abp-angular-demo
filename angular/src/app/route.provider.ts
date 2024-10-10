import { RoutesService, eLayoutType } from '@abp/ng.core';
import { APP_INITIALIZER } from '@angular/core';

export const APP_ROUTE_PROVIDER = [
  { provide: APP_INITIALIZER, useFactory: configureRoutes, deps: [RoutesService], multi: true },
];

function configureRoutes(routes: RoutesService) {
  return () => {
    routes.add([
      {
        path: '/',
        name: '::Menu:Home',
        iconClass: 'fas fa-home',
        order: 1,
        layout: eLayoutType.application,
      },
      {
        path: '/staff-management',
        name: '::Menu:StaffManageMent',
        iconClass: 'md md-people',
        order: 2,
        layout: eLayoutType.application,
        requiredPolicy: 'DemoStaff.Staffs || DemoStaff.Departments',
      },
      {
        path: '/staffs',
        name: '::Menu:Staffs',
        iconClass: 'bi bi-people-fill',
        parentName: '::Menu:StaffManageMent',
        layout: eLayoutType.application,
        requiredPolicy: 'DemoStaff.Staffs',
      },
      {
        path: '/departments',
        name: '::Menu:Departments',
        iconClass: 'bi bi-building',
        parentName: '::Menu:StaffManageMent',
        layout: eLayoutType.application,
        requiredPolicy: 'DemoStaff.Departments',
      },
    ]);
  };
}

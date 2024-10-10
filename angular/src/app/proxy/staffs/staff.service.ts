import type { DepartmentLookupDto, StaffDto, UpsertStaffDto } from './models';
import { RestService, Rest } from '@abp/ng.core';
import type { ListResultDto, PagedAndSortedResultRequestDto, PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class StaffService {
  apiName = 'Default';
  

  create = (input: UpsertStaffDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, StaffDto>({
      method: 'POST',
      url: '/api/app/staff',
      body: input,
    },
    { apiName: this.apiName,...config });
  

  delete = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/staff/${id}`,
    },
    { apiName: this.apiName,...config });
  

  get = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, StaffDto>({
      method: 'GET',
      url: `/api/app/staff/${id}`,
    },
    { apiName: this.apiName,...config });
  

  getDepartmentLookup = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, ListResultDto<DepartmentLookupDto>>({
      method: 'GET',
      url: '/api/app/staff/department-lookup',
    },
    { apiName: this.apiName,...config });
  

  getList = (input: PagedAndSortedResultRequestDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<StaffDto>>({
      method: 'GET',
      url: '/api/app/staff',
      params: { sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName,...config });
  

  update = (id: string, input: UpsertStaffDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, StaffDto>({
      method: 'PUT',
      url: `/api/app/staff/${id}`,
      body: input,
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}

import type { AuditedEntityDto, EntityDto } from '@abp/ng.core';
import type { Gender } from './gender.enum';

export interface DepartmentLookupDto extends EntityDto<string> {
  name?: string;
}

export interface StaffDto extends AuditedEntityDto<string> {
  name?: string;
  gender: Gender;
  email?: string;
  phone?: string;
  departmentId?: string;
  departmentName?: string;
  title?: string;
}

export interface UpsertStaffDto {
  name: string;
  gender: Gender;
  email: string;
  phone: string;
  title: string;
  departmentId?: string;
}

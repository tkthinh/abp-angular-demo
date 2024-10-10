import { ListService, PagedResultDto } from '@abp/ng.core';
import { Confirmation, ConfirmationService } from '@abp/ng.theme.shared';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { DepartmentDto, DepartmentService } from '@proxy/departments';

@Component({
  selector: 'app-department',
  templateUrl: './department.component.html',
  styleUrl: './department.component.scss',
  providers: [ListService],
})
export class DepartmentComponent implements OnInit {
  department = { items: [], totalCount: 0 } as PagedResultDto<DepartmentDto>;

  selectedDepartment = {} as DepartmentDto;

  form: FormGroup;

  isModalOpen = false;

  constructor(
    public readonly list: ListService,
    private departmentService: DepartmentService,
    private fb: FormBuilder,
    private confirm: ConfirmationService
  ) {}

  ngOnInit(): void {
      const departmentStreamCreator = query => this.departmentService.getList(query);

      this.list.hookToQuery(departmentStreamCreator).subscribe(response => {
        this.department = response;
      });
  }

  createDepartment() {
    this.selectedDepartment = {} as DepartmentDto;
    this.buildForm();
    this.isModalOpen = true;
  }

  updateDepartment(id: string) {
    this.departmentService.get(id).subscribe(department => {
      this.selectedDepartment = department;
      this.buildForm();
      this.isModalOpen = true;
    });
  }

  deleteDepartment(id: string) {
    this.confirm.warn('::AreYouSureToDelete', '::AreYouSure').subscribe(status => {
      if (status === Confirmation.Status.confirm) {
        this.departmentService.delete(id).subscribe(() => this.list.get());
      }
    });
  }
  
  buildForm() {
    this.form = this.fb.group({
      name: [this.selectedDepartment.name || '', Validators.required],
    });
  }

  save() {
    if (this.form.invalid) {
      return;
    }

    if (this.selectedDepartment.id) {
      this.departmentService.update(this.selectedDepartment.id, this.form.value).subscribe(() => {
        this.isModalOpen = false;
        this.list.get();
      });
    } else {
      this.departmentService.create(this.form.value).subscribe(() => {
        this.isModalOpen = false;
        this.list.get();
      });
    }
  }

  delete(id: string) {
    this.confirm.warn('::AreYouSureToDelete', '::AreYouSure').subscribe(status => {
      if (status === Confirmation.Status.confirm) {
        this.departmentService.delete(id).subscribe(() => this.list.get());
      }
    });
  }
}

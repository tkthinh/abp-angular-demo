import { ListService, PagedResultDto } from '@abp/ng.core';
import { Component, OnInit } from '@angular/core';
import { StaffService, StaffDto, genderOptions } from '@proxy/staffs';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Confirmation, ConfirmationService } from '@abp/ng.theme.shared';
import { DepartmentDto, DepartmentService, GetDepartmentListDto } from '@proxy/departments';

@Component({
  selector: 'app-staff',
  templateUrl: './staff.component.html',
  styleUrls: ['./staff.component.scss'],
  providers: [ListService],
})
export class StaffComponent implements OnInit {
  staff = { items: [], totalCount: 0 } as PagedResultDto<StaffDto>;

  selectedStaff = {} as StaffDto;

  deparments : DepartmentDto[] = [];

  form: FormGroup;

  genders = genderOptions;

  isModalOpen = false;

  constructor(
    public readonly list: ListService,
    private staffService: StaffService,
    private departmentService: DepartmentService,
    private fb: FormBuilder,
    private confirm: ConfirmationService
  ) {}

  ngOnInit() {
    const staffStreamCreator = query => this.staffService.getList(query);
    this.list.hookToQuery(staffStreamCreator).subscribe(response => {
      this.staff = response;
    });

    const reqParams: GetDepartmentListDto = { filter: '', maxResultCount: 10, skipCount: null, sorting: null};

    //fetch department list
    this.departmentService.getList(reqParams).subscribe(response => {
      this.deparments = response.items
    })
  }

  createStaff() {
    this.selectedStaff = {} as StaffDto;
    this.buildForm();
    this.isModalOpen = true;
  }

  updateStaff(id: string) {
    this.staffService.get(id).subscribe(staff => {
      this.selectedStaff = staff;
      this.buildForm();
      this.isModalOpen = true;
    });
  }

  deleteStaff(id: string) {
    this.confirm.warn('::AreYouSureToDelete', '::AreYouSure').subscribe(status => {
      if (status === Confirmation.Status.confirm) {
        this.staffService.delete(id).subscribe(() => this.list.get());
      }
    });
  }

  buildForm() {
    this.form = this.fb.group({
      name: [this.selectedStaff.name || '', Validators.required],
      gender: [
        this.selectedStaff.gender !== undefined ? this.selectedStaff.gender : null,
        Validators.required,
      ],
      email: [this.selectedStaff.email || null, Validators.required],
      phone: [this.selectedStaff.phone || null, Validators.required],
      departmentId: [this.selectedStaff.departmentId || null, Validators.required],
      title: [this.selectedStaff.title || null, Validators.required],
    });
  }

  save() {
    if (this.form.invalid) {
      return;
    }

    const request = this.selectedStaff.id
      ? this.staffService.update(this.selectedStaff.id, this.form.value)
      : this.staffService.create(this.form.value);

    request.subscribe(() => {
      this.isModalOpen = false;
      this.form.reset();
      this.list.get();
    });
  }
}

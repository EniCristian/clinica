import { AfterViewInit, Component, Input, OnInit } from '@angular/core';
import { ColumnModel } from './model/column.model';
import { DataRequestService } from './services/data-request.service';
import { map } from 'rxjs/operators';
import { PageEvent } from '@angular/material/paginator';
import { PaginationModel } from './model/pagination.model';
import { Router } from '@angular/router';
import { MatDialog } from '@angular/material/dialog';
import { TranslateService } from '@ngx-translate/core';
import { ToastrService } from 'ngx-toastr';
import { SortModel } from './model/sort.model';
import { DatePipe } from '@angular/common';
import { DeleteConfirmationModalComponent } from '../../common/delete-confirmation-modal/delete-confirmation-modal.component';
import { FilterValueModel } from './model/filter-value.model';
import { ActionModel } from './model/action.model';
import { Sort } from '@angular/material/sort';

@Component({
  selector: 'app-data-table',
  templateUrl: './data-table.component.html',
  styleUrls: ['./data-table.component.scss'],
})
export class DataTableComponent implements AfterViewInit, OnInit {
  @Input('resourceUrl')
  set setResourceUrl(url: string) {
    this.resourceUrl = url;
    if (this.initialized) {
      this.initDataSource();
    }
  }

  @Input('columns')
  set setColumns(columns: Map<string, ColumnModel>) {
    this.columns = columns;
    this.headerColumns = Array.from(this.columns.keys());
    this.allHeaderColumns = [...this.headerColumns];
    if (this.availableActions) {
      this.allHeaderColumns.push('actions');
    }
  }

  @Input('availableActions')
  set setAvailableActions(availableActions: boolean) {
    this.availableActions = availableActions;
    if (this.allHeaderColumns) {
      if (this.availableActions) {
        this.allHeaderColumns.push('actions');
      } else {
        this.allHeaderColumns = this.allHeaderColumns.filter(
          (col) => col !== 'actions'
        );
      }
    }
  }

  @Input('data')
  set setData(data: any) {
    this.data = data;
    this.initDataSource();
  }

  @Input()
  actions = ['edit', 'delete'];
  @Input()
  pageSizeOptions = [5, 10, 25, 100];
  @Input()
  startingPageSize = 10;
  @Input()
  startingPageNumber = 1;
  @Input()
  title: string | undefined;
  @Input()
  simpleHeader = false;
  @Input()
  routePrefix!: string;
  @Input()
  uniqueIdentifier = 'id';
  @Input()
  customResourceDeleteUrl: string | undefined;
  @Input()
  deleteDialogData: any;
  @Input()
  sort!: SortModel;
  @Input()
  additionalActions: ActionModel[] = [];

  columns!: Map<string, ColumnModel>;
  allHeaderColumns!: string[];
  headerColumns!: string[];
  resourceUrl!: string;
  availableActions = true;
  data: any;

  dataSource: any;
  pagination!: PaginationModel;

  filters: FilterValueModel[] = [];

  private initialized = false;

  constructor(
    private dataRequestService: DataRequestService,
    private router: Router,
    private dialog: MatDialog,
    private translateService: TranslateService,
    private toastrService: ToastrService
  ) {}

  ngAfterViewInit(): void {
    this.initDataSource();
  }

  ngOnInit(): void {
    this.initDataSource();
  }

  hasAccess(action: string): boolean {
    return this.actions.filter((p) => p === action).length > 0;
  }

  onPageChange(event: PageEvent): void {
    // Page number starts from 1 on the back-end side but is managed internally starting from 0 by MaterialUI
    const pageNumber = event.pageIndex + 1;

    this.getAllPaginated(
      new PaginationModel(event.pageSize, pageNumber),
      this.sort
    );
  }

  edit(row: any): void {
    this.router.navigate([this.routePrefix + '/' + row[this.uniqueIdentifier]]);
  }

  delete(row: any): void {
    const modalRef = this.dialog.open(DeleteConfirmationModalComponent, {
      id: row[this.uniqueIdentifier],
      data: this.mapDeleteDialogData(row),
    });
    modalRef.afterClosed().subscribe((result) => {
      if (result === 1) {
        this.deleteItem(row[this.uniqueIdentifier]);
      }
    });
  }

  private mapDeleteDialogData(row: any): any {
    if (this.deleteDialogData) {
      let messageParams = {};
      if (Array.isArray(this.deleteDialogData.messageParams)) {
        this.deleteDialogData.messageParams.forEach((element: string) => {
          messageParams = {
            ...messageParams,
            [element]: row[element],
          };
        });
      } else {
        messageParams = {
          [this.deleteDialogData.messageParams]:
            row[this.deleteDialogData.messageParams],
        };
      }
      return { ...this.deleteDialogData, messageParams };
    }
    return this.deleteDialogData;
  }

  refresh(): void {
    this.getAllPaginated(this.pagination, this.sort);
  }

  onSort(event: Sort): void {
    if (event.direction && event.active) {
      this.getAllPaginated(
        this.pagination,
        new SortModel(event.active, event.direction)
      );
    } else {
      this.getAllPaginated(this.pagination);
    }
  }

  private initDataSource(): void {
    if (!this.initialized) {
      this.pagination = new PaginationModel(
        this.startingPageSize,
        this.startingPageNumber
      );
      this.getAllPaginated(this.pagination, this.sort);
      this.initialized = true;
    }
  }

  private deleteItem(id: string): void {
    const url = this.customResourceDeleteUrl
      ? this.customResourceDeleteUrl
      : this.resourceUrl;

    this.dataRequestService.delete(url, id).subscribe(() => {
      this.toastrService.success(
        this.translateService.instant('MATERIAL_DATA_TABLE_DELETE_SUCCESSFUL')
      );
      this.refresh();
    });
  }

  private getAllPaginated(pagination: PaginationModel, sort?: SortModel): void {
    if (this.resourceUrl) {
      this.dataRequestService
        .getAll(this.resourceUrl, this.data, pagination, sort, this.filters)
        .pipe(
          map((data) => {
            this.dataSource = data.items;
            this.pagination = data.pagination;
            this.sort = data.sort;
          })
        )
        .subscribe();
    } else {
      this.paginateData(pagination, sort);
    }
  }

  private paginateData(pagination: PaginationModel, sort?: SortModel): void {
    this.pagination = {
      ...pagination,
      totalItems: this.data.pagination.totalItems,
    };
    let values = this.data.items;
    if (sort !== undefined) {
      values = values.sort(
        (n1: any, n2: any) =>
          (n1[sort.parameter] < n2[sort.parameter] ? -1 : 1) *
          (sort.order === 'asc' ? 1 : -1)
      );
    }
    this.dataSource = values.slice(
      (this.pagination.pageNumber - 1) * this.pagination.pageSize,
      this.pagination.pageNumber * this.pagination.pageSize
    );
  }

  private getNestedProperty(row: any, column: any): string {
    const columnNestedProperties = column.split('.');
    let result = '';
    let additionalParam = row;
    columnNestedProperties.forEach((property: any) => {
      result = additionalParam[property];
      additionalParam = result;
    });

    return result;
  }

  private getListNestedProperty(row: any, column: string): string {
    const indexOfFirst = column.indexOf('.');
    const columnNestedProperties = column.substring(
      indexOfFirst + 1,
      column.length
    );
    const arrayPropName = column.substring(0, indexOfFirst);
    const arrayProp = row[arrayPropName];
    const result = new Set();
    if (Array.isArray(arrayProp)) {
      arrayProp.forEach((value) =>
        result.add(this.getNestedProperty(value, columnNestedProperties))
      );
    }
    return [...result].join(', ');
  }

  getColumnValue(row: any, column: string): string {
    const columnSpecialType = this.columns.get(column)?.specialType;
    if (columnSpecialType === 'listValue') {
      return this.getListNestedProperty(row, column);
    } else {
      if (column.includes('+')) {
        const columnProperties = column.split(' + ');
        let result = '';
        columnProperties.forEach((property) => {
          result = `${result} ${this.getNestedProperty(row, property)}`;
        });

        return result;
      }
      if (column.includes('.')) {
        const result = this.getNestedProperty(row, column);
        return result;
      }

      if (columnSpecialType === 'date') {
        const pipe = new DatePipe('en-US');
        return pipe.transform(row[column], 'dd/MM/yyyy - HH:mm') ?? '';
      } else if (columnSpecialType === 'shortDate') {
        const pipe = new DatePipe('en-US');
        return pipe.transform(row[column], 'dd/MM/yyyy') ?? '';
      } else if (columnSpecialType === 'binaryValue') {
        return row[column] === 0
          ? this.translateService.instant('GENERAL_NEGATIVE')
          : this.translateService.instant('GENERAL_POSITIVE');
      }
    }
    return row[column];
  }

  onFilterChanged(event: FilterValueModel[]): void {
    this.filters = event;
    this.pagination = new PaginationModel(
      this.startingPageSize,
      this.startingPageNumber
    );
    this.getAllPaginated(this.pagination, this.sort);
  }
}

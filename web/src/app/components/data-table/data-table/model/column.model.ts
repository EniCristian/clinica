import { FilterModel } from './filter.model';

export class ColumnModel {
  headerName!: string;
  sortable: boolean = false;
  specialType?: string;
  filterable?: FilterModel;
  class?: string;
}

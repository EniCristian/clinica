import { FilterModel } from './filter.model';

export class ColumnModel {
  headerName!: string;
  sortable?: boolean;
  specialType?: string;
  filterable?: FilterModel;
}

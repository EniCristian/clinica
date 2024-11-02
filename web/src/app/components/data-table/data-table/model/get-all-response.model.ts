import { PaginationModel } from './pagination.model';
import { SortModel } from './sort.model';

export class GetAllResponseModel {
  items!: any[];
  pagination!: PaginationModel;
  sort!: SortModel;
}

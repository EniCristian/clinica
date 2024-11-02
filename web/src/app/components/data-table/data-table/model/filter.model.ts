import { Observable } from 'rxjs';
import { FilterValueModel } from './filter-value.model';

export class FilterModel {
  queryParamName!: string;
  filterValue?: string;
  options$?: Observable<FilterValueModel[]>;
}

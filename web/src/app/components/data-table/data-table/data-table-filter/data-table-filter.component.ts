import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { ColumnModel } from '../model/column.model';
import { FilterValueModel } from '../model/filter-value.model';

@Component({
  selector: 'app-data-table-filter',
  templateUrl: './data-table-filter.component.html',
})
export class DataTableFilterComponent implements OnInit {
  @Output()
  filterChanged = new EventEmitter<FilterValueModel[]>() || undefined;

  @Input('columns')
  set setColumns(columns: Map<string, ColumnModel>) {
    this.columns = columns;
    this.filters = [...columns.entries()]
      .filter((entry) => entry[1].filterable !== undefined)
      .map((entry) => entry[1]);
  }

  columns: Map<string, ColumnModel> | undefined;
  filters: ColumnModel[] = [];

  ngOnInit(): void {}

  filterChange(filter: ColumnModel, event: any): void {
    if (filter.filterable) {
      filter.filterable.filterValue = event.target.value;
      this.emitFilterChanged();
    }
  }

  private emitFilterChanged(): void {
    const filters = this.filters
      .filter(
        (filter) =>
          filter.filterable?.filterValue !== undefined &&
          filter.filterable.filterValue !== ''
      )
      .map(
        (filter) =>
          ({
            name: filter.filterable?.queryParamName,
            value: filter.filterable?.filterValue,
          } as FilterValueModel)
      );
    this.filterChanged.emit(filters);
  }
}

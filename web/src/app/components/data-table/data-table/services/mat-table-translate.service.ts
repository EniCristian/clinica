import { Injectable } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { MatPaginatorIntl } from '@angular/material/paginator';

@Injectable({
  providedIn: 'root',
})
export class MatTableTranslateService {
  constructor(private translateService: TranslateService) {}

  public getPaginatorIntl(): MatPaginatorIntl {
    const paginatorIntl = new MatPaginatorIntl();
    paginatorIntl.itemsPerPageLabel = this.translateService.instant(
      'material_mat_table_items_per_page_label'
    );
    paginatorIntl.nextPageLabel = this.translateService.instant(
      'material_mat_table_next_page_label'
    );
    paginatorIntl.previousPageLabel = this.translateService.instant(
      'material_mat_table_previous_page_label'
    );
    paginatorIntl.firstPageLabel = this.translateService.instant(
      'material_mat_table_first_page_label'
    );
    paginatorIntl.lastPageLabel = this.translateService.instant(
      'material_mat_table_last_page_label'
    );
    paginatorIntl.getRangeLabel = this.getRangeLabel.bind(this);
    return paginatorIntl;
  }

  private getRangeLabel(
    page: number,
    pageSize: number,
    length: number
  ): string {
    if (length === 0 || pageSize === 0) {
      return this.translateService.instant(
        'material_mat_table_range_page_label_1',
        { length }
      );
    }

    length = Math.max(length, 0);
    const startIndex = page * pageSize;

    // If the start index exceeds the list length, do not try and fix the end index to the end.
    const endIndex =
      startIndex < length
        ? Math.min(startIndex + pageSize, length)
        : startIndex + pageSize;
    return this.translateService.instant(
      'material_mat_table_range_page_label_2',
      { startIndex: startIndex + 1, endIndex, length }
    );
  }
}

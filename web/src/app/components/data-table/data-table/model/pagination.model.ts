export class PaginationModel {
  pageSize: number;
  pageNumber: number;
  totalItems: number | null;

  constructor(
    pageSize: number,
    pageNumber: number,
    totalItems: number | null = null
  ) {
    this.pageSize = pageSize;
    this.pageNumber = pageNumber;
    this.totalItems = totalItems;
  }
}

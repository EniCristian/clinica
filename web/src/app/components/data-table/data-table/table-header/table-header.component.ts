import { Component, Input, Output } from '@angular/core';
import { Router } from '@angular/router';
import { EventEmitter } from '@angular/core';

@Component({
  selector: 'app-table-header',
  templateUrl: './table-header.component.html',
  styleUrls: ['./table-header.component.scss'],
})
export class TableHeaderComponent {
  @Input()
  title!: string;
  @Input()
  simpleHeader = false;
  @Input()
  routePrefix!: string;
  @Output()
  refreshTableEvent = new EventEmitter<void>();

  constructor(private router: Router) {}

  addNew(): void {
    this.router.navigate([this.routePrefix]);
  }

  refresh(): void {
    this.refreshTableEvent.emit();
  }
}

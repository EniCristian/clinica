import { NgModule } from '@angular/core';
import { DataTableComponent } from './data-table/data-table.component';
import { MatTableModule } from '@angular/material/table';
import { MatPaginatorIntl, MatPaginatorModule } from '@angular/material/paginator';
import { CommonsModule } from '../common/common.module';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { TableHeaderComponent } from './data-table/table-header/table-header.component';
import { MatSortModule } from '@angular/material/sort';
import { MatTableTranslateService } from './data-table/services/mat-table-translate.service';
import { TranslateService } from '@ngx-translate/core';
import { DataTableFilterComponent } from './data-table/data-table-filter/data-table-filter.component';
import { MatSelectModule } from '@angular/material/select';
import { SpecialistStatusModule } from '../components/admin/specialists/specialist-status/specialist-status.module';

@NgModule({
    declarations: [
        DataTableComponent,
        TableHeaderComponent,
        DataTableFilterComponent,
    ],
    imports: [
        CommonsModule,
        MatTableModule,
        MatPaginatorModule,
        MatIconModule,
        MatButtonModule,
        MatSortModule,
        MatSelectModule,
        SpecialistStatusModule,
    ],
    providers: [
        {
            provide: MatPaginatorIntl, deps: [TranslateService],
            useFactory: (translateService: TranslateService) => new MatTableTranslateService(translateService).getPaginatorIntl()
        }
    ],
    exports: [
        DataTableComponent
    ]
})
export class DataTableModule {
}

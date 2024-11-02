import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { PaginationModel } from '../model/pagination.model';
import { environment } from '../../../../environments/environment';
import { SortModel } from '../model/sort.model';
import { GetAllResponseModel } from '../model/get-all-response.model';
import { FilterValueModel } from '../model/filter-value.model';
import { filter } from 'rxjs/operators';

@Injectable({
    providedIn: 'root',
})
export class DataRequestService {
    constructor(private httpClient: HttpClient) { }
    getAll(
        url: string,
        data: any,
        pagination: PaginationModel,
        sort?: SortModel,
        filters?: FilterValueModel[]
    ): Observable<GetAllResponseModel> {
        let params = new HttpParams()
            .set('pageNumber', String(pagination.pageNumber))
            .set('pageSize', String(pagination.pageSize));

        if (data) {
            for (const key of Object.keys(data)) {
                params = params.set(key, data[key]);
            }
        }
        if (filters) {
            filters.forEach(f => {
                params = params.set(f.name, f.value);
            });
        }

        if (sort) {
            params = params
                .set('sortParameter', sort.parameter)
                .set('sortOrder', sort.order);
        }
        return this.httpClient.get<GetAllResponseModel>(
            environment.apiBaseUrl + url,
            { params }
        );
    }

    delete(url: string, id: string): Observable<any> {
        return this.httpClient.delete(environment.apiBaseUrl + url + '/' + id);
    }
}

export class SortModel {

    parameter: string;
    order: 'asc' | 'desc';

    constructor(parameter: string, order: 'asc' | 'desc') {
        this.parameter = parameter;
        this.order = order;
    }

}

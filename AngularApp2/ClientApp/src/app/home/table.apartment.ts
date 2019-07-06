import { Apartment } from './apartment';
import { ApartmentFilter } from './apartment.filter';

export class TableApartment {
  constructor(
    //public page?: number,
    public count?: number,
    public totalPages?: number,
    public nextPage: boolean = false,
    public apartments: Apartment[] = [],
    public filter: ApartmentFilter = new ApartmentFilter()
  ) { }
}

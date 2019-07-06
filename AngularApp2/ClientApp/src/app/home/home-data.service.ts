import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Apartment } from './apartment';

@Injectable()
export class DataService {

  private url = "/api/apartments/";
  private url2 = "/api/apartments/getpaged2";

  constructor(private http: HttpClient) {
  }

  getApartments() {
    return this.http.get(this.url);
  }

  getApartment(id: number) {
    return this.http.get(this.url + 'get/' + id);
  }

  getApartmentsPaged(
    sortField: string,
    sortOrder: string,
    commonAreaFrom: number,
    commonAreaTo: number,
    kitchenAreaFrom: number,
    kitchenAreaTo: number,
    costFrom: number,
    costTo: number,
    page: number
  ) {
    if (!sortField)
      sortField = "";
    if (!sortOrder)
      sortField = "";
    if (!commonAreaFrom)
      commonAreaFrom = 0;
    if (!commonAreaTo)
      commonAreaTo = 0;
    if (!kitchenAreaFrom)
      kitchenAreaFrom = 0;
    if (!kitchenAreaTo)
      kitchenAreaTo = 0;
    if (!page)
      page = 1;
    if (!costFrom)
      costFrom = 0;
    if (!costTo)
      costTo = 0;

    return this.http.get(this.url + "getpaged2"
      + "?sortField=" + sortField
      + "&sortOrder=" + sortOrder
      + "&commonAreaFrom=" + commonAreaFrom
      + "&commonAreaTo=" + commonAreaTo
      + "&kitchenAreaFrom=" + kitchenAreaFrom
      + "&kitchenAreaTo=" + kitchenAreaTo
      + "&costFrom=" + costFrom
      + "&costTo=" + costTo
      + "&page=" + page);
  }

  //createProduct(product: Product) {
  //    return this.http.post(this.url, product);
  //}
  updateProduct(apartment: Apartment) {
    return this.http.put(this.url + "update/", apartment);
    //return this.http.put(this.url + '/' + apartment.id, apartment);
  }
  deleteApartment(id: number) {
    return this.http.delete(this.url + "delete/" + id);
  }
}

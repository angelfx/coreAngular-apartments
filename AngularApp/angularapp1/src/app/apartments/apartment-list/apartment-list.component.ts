import { Component, OnInit } from '@angular/core';
import { ApartmentDataService } from '../apartment-data.service';
import { Apartment } from '../apartment';
import { TableApartment } from '../table.apartment';
import { Sort } from '../sort';
import { ApartmentFilter } from '../apartment.filter';

@Component({
  selector: "app-home",
  templateUrl: './apartment-list.component.html',
  providers: [ApartmentDataService]
})

export class ApartmentListComponent implements OnInit {

  apartment: Apartment = new Apartment();   // editable apartment
  tableApartment: TableApartment = new TableApartment(); //Model for table view. Contains data for filter
  tableMode: boolean = true;          // table mode
  sort: Sort[] = []; //Data for sort
  selectedSort: string = "districtTitle:asc"; //Value for default sort
  idApartment: number = 0;

  constructor(private dataService: ApartmentDataService) { }

  ngOnInit() {
    //Set list of settings for sorting. May be we must get it from backend
    this.selectedSort = "districtTitle:asc";
    this.sort.push(new Sort("-", ""));
    this.sort.push(new Sort("District ascending", "districtTitle:asc"));
    this.sort.push(new Sort("Common area ascending", "commonArea:asc"));
    this.sort.push(new Sort("Common area descending", "commonArea:desc"));
    this.sort.push(new Sort("Kitchen area ascending", "kitchenArea:asc"));
    this.sort.push(new Sort("Kitchen area descending", "kitchenArea:desc"));
    this.sort.push(new Sort("Cost ascending", "cost:asc"));
    this.sort.push(new Sort("Cost ascending", "cost:desc"));
    this.tableApartment.filter = new ApartmentFilter(); //Set empty filter
    this.loadProducts();    // load data
  }

  // load data with sort and filter settings
  loadProducts() {
    this.dataService.getApartmentsPaged(
      this.tableApartment.filter.sortField,
      this.tableApartment.filter.sortOrder,
      this.tableApartment.filter.commonAreaFrom,
      this.tableApartment.filter.commonAreaTo,
      this.tableApartment.filter.kitchenAreaFrom,
      this.tableApartment.filter.kitchenAreaTo,
      this.tableApartment.filter.costFrom,
      this.tableApartment.filter.costTo,
      this.tableApartment.filter.page
    )
      .subscribe((data: TableApartment) => this.tableApartment = data);
  }

  //Search data from user request
  search() {
    if (this.selectedSort != "") {
      let valArr = this.selectedSort.split(':');
      this.tableApartment.filter.sortField = valArr[0];
      this.tableApartment.filter.sortOrder = valArr[1];
    }
    this.loadProducts();
  }

  //Next page
  next() {

    //if (this.tableApartment.filter.page < this.tableApartment.totalPages) {
    if (this.tableApartment.nextPage === true) {
      this.tableApartment.filter.page = this.tableApartment.filter.page + 1;
      this.loadProducts();
    }

  }

  //Previous page
  previous() {
    if (this.tableApartment.filter.page > 1) {
      this.tableApartment.filter.page = this.tableApartment.filter.page - 1;
      this.loadProducts();
    }
  }

  //Show modal window with details
  showApartment(a: Apartment) {
    this.apartment = a;

    var modal = document.getElementById('exampleModal');
    modal.style.display = 'block';
  }

  //Close modal
  closeApartment() {
    this.apartment = new Apartment();

    var modal = document.getElementById('exampleModal');
    modal.style.display = 'none';
  }

  //Update apartment
  updateApartment() {
    this.dataService.updateProduct(this.apartment)
      .subscribe(data => this.loadProducts());
    this.cancel();
  }

  //Edit apartment in list
  editApartment(p: Apartment) {
    this.apartment = p;
    this.idApartment = p.id;
  }

  //Cancel edit
  cancel() {
    this.apartment = new Apartment();
    this.idApartment = 0;
    this.tableMode = true;
  }

  //Delete apartment
  delete(p: Apartment) {
      this.dataService.deleteApartment(p.id)
          .subscribe(data => this.loadProducts());
  }
}

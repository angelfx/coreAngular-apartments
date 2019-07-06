import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { DataService } from './home-data.service';
import { Apartment } from './apartment';

@Component({
  templateUrl: './apartment-edit.component.html'
})
export class ApartmentEditComponent implements OnInit {

  id: number;
  apartment: Apartment;
  loaded: boolean = false;

  constructor(private dataService: DataService, private router: Router, activeRoute: ActivatedRoute) {
    this.id = Number.parseInt(activeRoute.snapshot.params["id"]);
  }

  ngOnInit() {
    if (this.id)
      this.dataService.getApartment(this.id)
        .subscribe((data: Apartment) => {
          this.apartment = data;
          if (this.apartment != null) this.loaded = true;
        });
  }

  save() {
    this.dataService.updateProduct(this.apartment).subscribe(data => this.router.navigateByUrl("/"));
  }
}

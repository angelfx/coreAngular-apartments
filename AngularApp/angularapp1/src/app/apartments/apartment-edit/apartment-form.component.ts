import { Component, Input } from '@angular/core';
import { Apartment } from '../apartment';

@Component({
  selector: "apartment-form",
  templateUrl: './apartment-form.component.html'
})

export class ApartmentFormComponent {
  @Input() apartment: Apartment;
}

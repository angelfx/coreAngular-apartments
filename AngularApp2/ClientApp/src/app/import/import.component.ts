import { Component } from '@angular/core';
import { ImportDataService } from './import-data.service';

@Component({
  selector: 'app-import',
  templateUrl: './import.component.html'
})
export class ImportComponent {
  result: string = "Click import to load initial data";

  constructor(private dataService: ImportDataService) { }

  import() {
    this.dataService.import().subscribe((data: string) => this.result = "Import finished");
  }
}

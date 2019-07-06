import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class ImportDataService {

  private url = "/api/import/";

  constructor(private http: HttpClient) {
  }

  import() {
    return this.http.post(this.url + "/import", null);
  }
}

import { Component, OnInit } from '@angular/core';

@Component({
    selector: "app-home",
    templateUrl: './home.component.html',
    //providers: [DataService]
  })

  export class HomeComponent implements OnInit {
    title: string;

    ngOnInit() {
        this.title="Real Estates";
    }

  }
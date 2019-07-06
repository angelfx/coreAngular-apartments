import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { ApartmentFormComponent } from './home/apartment-form.component';
import { GroupByPipe } from './pipes/pipe.groupby';
import { ApartmentEditComponent } from './home/apartment-edit.component';
import { ImportComponent } from './import/import.component';

import { DataService } from './home/home-data.service';
import { ImportDataService } from './import/import-data.service';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    GroupByPipe,
    ApartmentEditComponent,
    ApartmentFormComponent,
    ImportComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'import', component: ImportComponent },
      { path: 'edit/:id', component: ApartmentEditComponent },
    ])
  ],
  providers: [DataService, ImportDataService],
  bootstrap: [AppComponent]
})
export class AppModule { }

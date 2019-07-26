import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { ImportDataService } from './import/import-data.service';
import { ApartmentDataService } from './apartments/apartment-data.service';

import { HomeComponent } from './home/home.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';

import { GroupByPipe } from './pipes/groupby.pipe';
import { ApartmentFormComponent } from './apartments/apartment-edit/apartment-form.component';
import { ApartmentEditComponent } from './apartments/apartment-edit/apartment-edit.component';
import { ApartmentListComponent } from './apartments/apartment-list/apartment-list.component';
import { ImportComponent } from './import/import.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    NavMenuComponent,
    ApartmentFormComponent,
    ApartmentEditComponent,
    ApartmentListComponent,
    GroupByPipe,
    ImportComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    AppRoutingModule
  ],
  providers: [ImportDataService, ApartmentDataService],
  bootstrap: [AppComponent]
})
export class AppModule { }

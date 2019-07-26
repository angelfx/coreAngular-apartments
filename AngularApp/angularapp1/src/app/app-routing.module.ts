import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { HomeComponent } from './home/home.component';
//import { ApartmentFormComponent } from './apartments/apartment-edit/apartment-form.component';
//import { GroupByPipe } from './pipes/pipe.groupby';
import { ApartmentEditComponent } from './apartments/apartment-edit/apartment-edit.component';
import { ImportComponent } from './import/import.component';
import { ApartmentListComponent } from './apartments/apartment-list/apartment-list.component';

const routes: Routes = [
  { path: '', component: HomeComponent, pathMatch: 'full' },
  { path: 'import', component: ImportComponent },
  { path: 'apartments/edit/:id', component: ApartmentEditComponent },
  { path: 'apartments', component: ApartmentListComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

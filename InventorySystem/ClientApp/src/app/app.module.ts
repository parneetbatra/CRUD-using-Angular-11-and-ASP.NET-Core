import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { ComputerTypeListComponent } from './computer-type/computer-type-list/computer-type-list.component';
import { ComputerTypeCreateComponent } from './computer-type/computer-type-create/computer-type-create.component';
import { ComputerTypeUpdateComponent } from './computer-type/computer-type-update/computer-type-update.component';
import { PropertiesCreateComponent } from './properties/properties-create/properties-create.component';
import { PropertiesUpdateComponent } from './properties/properties-update/properties-update.component';
import { PropertiesListComponent } from './properties/properties-list/properties-list.component';
import { PropertiesDetailComponent } from './properties/properties-detail/properties-detail.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    ComputerTypeListComponent,
    ComputerTypeCreateComponent,
    ComputerTypeUpdateComponent,
    PropertiesCreateComponent,
    PropertiesUpdateComponent,
    PropertiesListComponent,
    PropertiesDetailComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'computer-type', component: ComputerTypeListComponent },
      { path: 'computer-type/create', component: ComputerTypeCreateComponent },
      { path: 'computer-type/:id', component: ComputerTypeUpdateComponent },

      { path: 'properties', component: PropertiesListComponent },
      { path: 'properties/create', component: PropertiesCreateComponent },
      { path: 'properties/:id', component: PropertiesUpdateComponent },
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

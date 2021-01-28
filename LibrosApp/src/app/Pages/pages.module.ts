import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from '../Shared/shared.module';
import { ApproutingModule } from '../approuting.module';
import { HttpClientModule } from '@angular/common/http';

import { AutorService } from '../Services/autor.service';

import { AutorComponent } from './autor/autor.component';
import { AutorListComponent } from './autor-list/autor-list.component';
import { LibroComponent } from './libro/libro.component';
import { LibroListComponent } from './libro-list/libro-list.component';
import { MainComponent } from './main/main.component';


@NgModule({
  declarations: [
    AutorComponent,
    AutorListComponent, 
    LibroComponent, 
    LibroListComponent, 
    MainComponent
  ],
  exports:[
    AutorComponent,
    AutorListComponent, 
    LibroComponent, 
    LibroListComponent,
    MainComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    ApproutingModule,
    HttpClientModule
  ],
  providers:[
    AutorService
  ]
})
export class PagesModule { }

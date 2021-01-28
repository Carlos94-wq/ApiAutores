import { Routes, RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';

import { MainComponent } from './main/main.component';
import { AutorComponent } from './autor/autor.component';
import { AutorListComponent } from './autor-list/autor-list.component';

const routes: Routes = [
    { path: 'Main', component: MainComponent,
      children: [
          { path: 'Autor', component: AutorComponent },
          { path: 'Autores', component: AutorListComponent },
      ]
    },
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class PagesRoutingModule {}

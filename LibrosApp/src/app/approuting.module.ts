import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PagesRoutingModule } from './Pages/pages.routes';
import { PageNotFoundComponent } from './Shared/page-not-found/page-not-found.component';

const routes: Routes = [
  { path: '', redirectTo:'/Main', pathMatch: 'full'},
  { path: '**', component: PageNotFoundComponent }
];

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forRoot(routes),
    PagesRoutingModule
  ],
  exports:[
    RouterModule
  ]
})
export class ApproutingModule { }

import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { AutorService } from 'src/app/Services/autor.service';

@Component({
  selector: 'app-autor-detail',
  templateUrl: './autor-detail.component.html',
  styles: [
  ]
})
export class AutorDetailComponent implements OnInit {

  //Salen errores porque no hay definidas propiedades en este punto
  public ModelList:any = {};

  constructor(
    private _Activated: ActivatedRoute,
    private _Service: AutorService
  ) { }

  ngOnInit(): void {
    this._Activated.params.subscribe( resp => {
      console.log(resp);
      this._Service.GetAutor(resp['id']).subscribe((resp:any) =>{
        this.ModelList = resp['data'];
        console.log(this.ModelList);
      })
    })
  }

}

import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AutorQueryFilters } from 'src/app/Models/AutorQueryFilters';
import { AutorService } from 'src/app/Services/autor.service';

@Component({
  selector: 'app-autor-list',
  templateUrl: './autor-list.component.html',
  styleUrls: ['./autor-list.component.css']
})
export class AutorListComponent implements OnInit {

  public Model = [];
  public Filters: AutorQueryFilters = new AutorQueryFilters();
  public form: FormGroup;
  public ShowAlert: boolean = false;
  public spiner: boolean = false;

  constructor(
    private _Service: AutorService, 
    private _Builder: FormBuilder,
    private _Router: Router
  ) { 

    this.form = this._Builder.group({
      nombre: [''],
      apellidos: [''],
      activo: ['']
    });
   
  }

  ngOnInit(): void {
    this.GetAutores();
  }

  public GetAutores(){

    this.spiner = true;

    this.Filters.Nombre = this.form.controls.nombre.value;
    this.Filters.Apellidos = this.form.controls.apellidos.value;
    this.Filters.Activo = this.form.controls.activo.value;
    
    this._Service.GetAutores(this.Filters).subscribe(resp =>{
      
      this.Model = resp['data'];
      this.spiner = false;

      if (this.Model.length === 0) {
        this.ShowAlert = true;
      }
      else{
        this.ShowAlert = false;
      }
    })
  }

  public NaviGateUrl( id: number ){
    this._Router.navigate(['Main/AutorDetail', id])
  }

}

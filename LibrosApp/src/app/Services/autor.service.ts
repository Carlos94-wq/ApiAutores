import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { AutorQueryFilters } from '../Models/AutorQueryFilters';

@Injectable()
export class AutorService {

    private Url = environment.BaseUrl;
    private headers: HttpHeaders;

    constructor(private _http:HttpClient){
        this.headers = new HttpHeaders();
        //this.headers.set('Content-Type','application/json')
    }

    public GetAutores(filter: AutorQueryFilters){
        return this._http.get(`${this.Url}Autor?activo=${filter.Activo}&nombre=${filter.Nombre}&apellidos=${filter.Apellidos}`);
    }

    public GetAutor(idx: number){
        return this._http.get(this.Url + 'Autor/' + idx);
    }

    public PostAutor(){
        
    }
}
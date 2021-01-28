import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable()
export class AutorService {

    private Url = environment.BaseUrl;
    private headers: HttpHeaders;

    constructor(private _http:HttpClient){
        this.headers = new HttpHeaders();
        //this.headers.set('Content-Type','application/json')
    }

    public GetAutores(){
        return this._http.get(this.Url + 'Autor');
    }
}
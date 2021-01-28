import { Component, OnInit } from '@angular/core';
import { AutorService } from 'src/app/Services/autor.service';

@Component({
  selector: 'app-autor',
  templateUrl: './autor.component.html',
  styleUrls: ['./autor.component.css']
})
export class AutorComponent implements OnInit {

  constructor(private _Services: AutorService) { }

  ngOnInit(): void {
  }

}

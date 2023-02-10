import { Component } from '@angular/core';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.css']
})
export class MainComponent {
  animals = [
    {Nome:"Vaca", Idade:"15", Cor:"Azul", Sexo:"Femea", Peso:"80kg"},
    {Nome:"Urso", Idade:"5",Cor:"Vermelho",Sexo:"Macho",Peso:"10kg"},
    {Nome:"Pato", Idade:"1",Cor:"Rosa",Sexo:"Macho",Peso:"20kg"}
  ]
}

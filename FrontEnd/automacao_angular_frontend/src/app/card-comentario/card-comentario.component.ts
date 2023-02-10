import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-card-comentario',
  templateUrl: './card-comentario.component.html',
  styleUrls: ['./card-comentario.component.css']
})
export class CardComentarioComponent {
  @Input() animal: {Nome:String, Idade:String, Cor:String, Sexo:String, Peso:String} = {Nome:"", Idade:"", Cor:"", Sexo:"", Peso:""};
}

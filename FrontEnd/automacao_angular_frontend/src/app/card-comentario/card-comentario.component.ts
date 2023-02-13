import { Component, Input, Output } from '@angular/core';
import  {ListService} from 'src/app/list-service.service';
import { Router } from '@angular/router';
import  {Animal} from '../Interfaces/Animal';

@Component({
  selector: 'app-card-comentario',
  templateUrl: './card-comentario.component.html',
  styleUrls: ['./card-comentario.component.css']
})
export class CardComentarioComponent {
  @Input() animal: {nome:String, idade:String, cor:String, sexo:String, peso:String} = {nome:"", idade:"", cor:"", sexo:"", peso:""};
  @Output() animalSaida: {nome:String, idade:String, cor:String, sexo:String, peso:String} = {nome:"", idade:"", cor:"", sexo:"", peso:""};
  Retorno: String= "";


  constructor(private listService : ListService, private router: Router) {
  }

  excluirAnimal(nome:String):void{
    this.listService.deleteUnique(nome).subscribe((retorno) => (this.Retorno = retorno));
    window.location.reload();
  }
  
  navegaEditarAnimal(animal:Animal):void{
    this.router.navigate(['/novoAnimal', animal]);
  }
}

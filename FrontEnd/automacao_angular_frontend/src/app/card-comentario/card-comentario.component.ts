import { Component, Input, OnInit, Output } from '@angular/core';
import  {ListService} from 'src/app/list.service';
import { Router } from '@angular/router';
import  {Animal} from '../Interfaces/Animal';

@Component({
  selector: 'app-card-comentario',
  templateUrl: './card-comentario.component.html',
  styleUrls: ['./card-comentario.component.css']
})
export class CardComentarioComponent implements OnInit{
  @Input() animal: {nome:String, idade:String, cor:String, sexo:String, peso:String} = {nome:"", idade:"", cor:"", sexo:"", peso:""};
  @Output() animalSaida: {nome:String, idade:String, cor:String, sexo:String, peso:String} = {nome:"", idade:"", cor:"", sexo:"", peso:""};
  Retorno: String= "";


  constructor(private listService : ListService, private router: Router) {
  }
  ngOnInit() {
    console.log(this.animal)
  }

  excluirAnimal(nome:String):void{
    this.listService.deleteUnique(nome).subscribe((retorno) => (this.Retorno = retorno));
    window.location.reload();
  }
  
  navegaEditarAnimal(animal:Animal):void{
    this.router.navigate(['/novoAnimal', animal]);
  }
}

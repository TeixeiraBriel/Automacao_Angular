import { Component } from '@angular/core';
import  {ListService} from 'src/app/list-service.service';
import  {Animal} from '../Animal';

@Component({
  selector: 'app-novo-animal',
  templateUrl: './novo-animal.component.html',
  styleUrls: ['./novo-animal.component.css']
})
export class NovoAnimalComponent {
  retorno: String = "";

  constructor(private listService : ListService) {
  }

  chamarNome(){
    var texto = ((document.getElementById("inputLero") as HTMLInputElement).value);
    this.listService.getUnique(texto).subscribe((retorno) => (this.retorno = retorno));
    console.log(this.retorno);
  }

  postar(dados: Animal) {
    console.log('Valor formulário', dados);
  }
  
}

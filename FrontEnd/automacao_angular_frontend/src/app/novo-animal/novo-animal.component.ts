import { Component } from '@angular/core';
import  {ListService} from 'src/app/list-service.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-novo-animal',
  templateUrl: './novo-animal.component.html',
  styleUrls: ['./novo-animal.component.css']
})
export class NovoAnimalComponent {
  retorno: String = "";

  constructor(private listService : ListService, private router: Router) {
  }

  chamarNome(){
    var texto = ((document.getElementById("inputLero") as HTMLInputElement).value);
    this.listService.getUnique(texto).subscribe();
    console.log(this.retorno);
  }

  postar(dados: any) {
    this.listService.createUnique(dados).subscribe((retorno) => (this.retorno = retorno));
    this.router.navigate(['Main']);
  }
  
}

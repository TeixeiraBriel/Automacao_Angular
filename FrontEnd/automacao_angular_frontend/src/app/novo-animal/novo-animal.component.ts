import { Component, Input } from '@angular/core';
import { ListService } from 'src/app/list-service.service';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';
import { Animal } from '../Animal';

@Component({
  selector: 'app-novo-animal',
  templateUrl: './novo-animal.component.html',
  styleUrls: ['./novo-animal.component.css']
})
export class NovoAnimalComponent {
  @Input() animal: { nome: String, idade: String, cor: String, sexo: String, peso: String } = { nome: "", idade: "", cor: "", sexo: "", peso: "" };
  AnimalEditar: Animal = { nome: "", idade: "", cor: "", sexo: "", peso: "" };
  Editar: boolean = false;
  Retorno: String = "";

  constructor(private listService: ListService, private router: Router, private route: ActivatedRoute) {
    this.route.params.subscribe(params => {
      this.AnimalEditar.nome = params['nome'];
      this.AnimalEditar.idade = params['idade'];
      this.AnimalEditar.cor = params['cor'];
      this.AnimalEditar.sexo = params['sexo'];
      this.AnimalEditar.peso = params['peso'];


      if (route.snapshot.paramMap.has('nome')) {
        this.Editar = true;
        this.preencherCampos();
      }
      else {
        this.Editar = false;
      }
    });
  }

  preencherCampos(){
    
  }

  postar(dados: any) {
    if (this.Editar) {
      this.listService.editUnique(dados).subscribe((retorno) => (this.Retorno = retorno));
    }
    else {
      this.listService.createUnique(dados).subscribe((retorno) => (this.Retorno = retorno));
    }

    this.router.navigate(['Main']);
  }
}
import { Component } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { MatStepper } from '@angular/material/stepper';
import { ListService } from 'src/app/list.service';
import { firstValueFrom, EMPTY } from 'rxjs'
import { Personagem } from '../Interfaces/Personagem';

@Component({
  selector: 'app-albion',
  templateUrl: './albion.component.html',
  styleUrls: ['./albion.component.css']
})
export class AlbionComponent {
  firstFormGroup = this._formBuilder.group({
    firstCtrl: ['', Validators.required],
  });
  secondFormGroup = this._formBuilder.group({
    secondCtrl: [''],
  });

  isEditable = false;
  listaNicknames: Personagem[] = [];
  RetornoDadosJogador: any = {
    Name: "", KillFame: "", DeathFame: "", LifetimeStatistics: {
      PvE: { Total: "" },
      Gathering: { All: { Total: "" } },
      Crafting: { Total: "" }
    },
    FishingFame: ""
  };

  nicknameSelecionado: String = "";
  inputNickname: String = "";

  constructor(private _formBuilder: FormBuilder, private listService: ListService) { }

  async segundoPasso(stepper: MatStepper) {
    this.listaNicknames = await firstValueFrom(await this.listService.albion_buscaPorNickname(this.inputNickname));

    if (this.listaNicknames.length > 0) {
      console.log(this.listaNicknames);
      stepper.next();
    }
    else {
      console.log("Vazio");
    }
  }

  async terceiroPasso(stepper: MatStepper) {
    this.RetornoDadosJogador = await firstValueFrom(await this.listService.albion_buscaDadosPorId(this.nicknameSelecionado));

    if (this.RetornoDadosJogador != "") {
      console.log(this.RetornoDadosJogador);
      stepper.next();
    }
    else {
      console.log("Vazio");
    }
  }

  changeClient(value: string) {
    this.nicknameSelecionado = value;
  }
}

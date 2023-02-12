import { Component } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { MatStepper } from '@angular/material/stepper';
import { ListService } from 'src/app/list-service.service';
import { firstValueFrom, EMPTY } from 'rxjs'

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
    secondCtrl: ['', Validators.required],
  });

  isEditable = false;
  listaNicknames: String[] = [];
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
}

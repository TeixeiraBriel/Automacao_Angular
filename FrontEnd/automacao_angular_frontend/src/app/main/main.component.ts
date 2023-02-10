import { Component } from '@angular/core';
import  {Animal} from '../Animal';
import  {ListService} from 'src/app/list-service.service';


@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.css']
})
export class MainComponent {
  animais: Animal[] = [];

  constructor(private listService : ListService) {
    this.getAnimals();
  }

  getAnimals():void{
    this.listService.getAll().subscribe((animais) => (this.animais = animais));
  }
}

import { Injectable } from '@angular/core';
import  {Animal} from './Animal';

import { HttpClient } from '@angular/common/http';
import {Observable} from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ListService {
  private apiUrl = "https://localhost:7002/api";

  constructor(private http:HttpClient) { }

  getAll():Observable<Animal[]>{
    return this.http.get<Animal[]>(this.apiUrl+"/Animal/Todos");
  }

  getUnique(Nome: string):Observable<string>{
    return this.http.get<string>(this.apiUrl+"/Animal/"+Nome);
  }
}

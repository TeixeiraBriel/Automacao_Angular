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

  getUnique(Nome: string):Observable<Animal>{
    return this.http.get<Animal>(this.apiUrl+"/Animal/"+Nome);
  }  
  
  createUnique(Animal: Animal):Observable<string>{
    return this.http.post<string>(this.apiUrl+"/Animal/novo", Animal);
  }

  deleteUnique(Nome: String):Observable<any>{
    return this.http.post<any>(this.apiUrl+"/Animal/remover/"+Nome, {});
  }
}

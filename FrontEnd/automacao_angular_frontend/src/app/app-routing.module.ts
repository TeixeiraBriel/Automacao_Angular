import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { MainComponent } from './main/main.component';
import { NovoAnimalComponent } from './novo-animal/novo-animal.component';

const routes: Routes = [
  {path: 'Login', component:LoginComponent},
  {path: 'Main', component:MainComponent},
  {path: 'novoAnimal', component:NovoAnimalComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

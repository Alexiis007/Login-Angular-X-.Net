import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Usuarios } from '../interfaces/usuarios';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class InventariosService {

  constructor(private http : HttpClient) { 
  }
  public getUsuarios():Observable<Usuarios[]>{
    return this.http.get<Usuarios[]>('http://localhost:5199/api/Usuarios')
  }

}

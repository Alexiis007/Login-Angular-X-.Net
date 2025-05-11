import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Usuarios } from '../../inventario/interfaces/usuarios';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private httpClient = inject(HttpClient);
  
  public getUser(id:number):Observable<Usuarios>{
    return this.httpClient.get<Usuarios>(`http://localhost:5199/api/usuarios/${id}`);
  }
}

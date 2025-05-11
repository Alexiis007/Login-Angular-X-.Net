import { Component, Inject, OnInit, inject } from '@angular/core';
import { InventariosService } from '../../Services/inventarios.service';
import { Usuarios } from '../../interfaces/usuarios';
@Component({
  selector: 'app-inventario',
  templateUrl: './inventario.component.html',
  styleUrl: './inventario.component.css'
})
export class InventarioComponent implements OnInit{
  public usuarios : Usuarios[] = [];
  private SInventario : InventariosService = inject(InventariosService)
  constructor(){
  }

  ngOnInit(): void {
    this.SInventario.getUsuarios().subscribe(res => this.usuarios=res)
  }
}

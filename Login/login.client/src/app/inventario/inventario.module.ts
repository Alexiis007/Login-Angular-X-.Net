import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { InventarioRoutingModule } from './inventario-routing.module';
import { InventarioComponent } from './pages/inventario/inventario.component';
import { LayoutComponent } from './shared/layout/layout.component';


@NgModule({
  declarations: [
    InventarioComponent,
    LayoutComponent
  ],
  imports: [
    CommonModule,
    InventarioRoutingModule
  ]
})
export class InventarioModule { }

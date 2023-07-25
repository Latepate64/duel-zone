import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TableComponent } from './table.component';
import { PlaymatComponent } from '../playmat/playmat.component';
import { ZoneComponent } from '../zone/zone.component';
import { RouterModule } from '@angular/router';
import { MatTableModule } from '@angular/material/table';
import { CardComponent } from '../card/card.component';


@NgModule({
  declarations: [
    TableComponent,
    PlaymatComponent,
    ZoneComponent,
    CardComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forChild([{ path: '', component: TableComponent }]),
    MatTableModule,
  ],
  exports: [
    TableComponent,
    PlaymatComponent,
    ZoneComponent
  ]
})
export class TableModule { }

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { SharedModule } from '../../shared';
import { DeckBuilderComponent } from './deck-builder.component';
import { CardCollectionComponent } from './card-collection/card-collection.component';
import { DeckComponent } from './deck/deck.component';
import { MatTableModule } from '@angular/material/table';

@NgModule({
  declarations: [DeckBuilderComponent, CardCollectionComponent, DeckComponent],
  imports: [
    CommonModule,
    SharedModule,
    RouterModule.forChild([{ path: '', component: DeckBuilderComponent }]),
    MatTableModule
  ],
})
export class DeckBuilderModule { }

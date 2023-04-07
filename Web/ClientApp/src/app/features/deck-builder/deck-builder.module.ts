import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { SharedModule } from '../../shared';
import { DeckBuilderComponent } from './deck-builder.component';

@NgModule({
  declarations: [DeckBuilderComponent],
  imports: [
    CommonModule,
    SharedModule,
    RouterModule.forChild([{ path: '', component: DeckBuilderComponent }]),
  ],
})
export class DeckBuilderModule { }

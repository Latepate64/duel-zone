import { Component, Injectable, NgModule } from '@angular/core';
import { Observable, of } from 'rxjs';

//import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-deck',
  templateUrl: './deck.component.html'
})

@Injectable({ providedIn: 'root' })
export class DeckComponent {
  id: number = 0;
  public deckCards: DeckCard[] = []
  public columnsToDisplay = ['quantity', 'name', 'remove'];
  //public deckCards: Observable<DeckCard[]> = of([]); // = [{ id: this.id++, quantity: 1, name: "Example" }];

  public onAdded(cardName: string) {
    let foo = this.deckCards;
    foo.push({ id: this.id++, quantity: 1, name: cardName });
    this.deckCards = foo;
    //foo.
    
    //this.deckCards.push({ id: this.id++, quantity: 1, name: cardName });
  }

  identify(index: number, item: DeckCard) {
    return item.id;
  }

  //ngOnInit() {
  //  this.deckCards.subscribe()
  //}
}

interface DeckCard {
  id: number;
  quantity: number;
  name: string;
}

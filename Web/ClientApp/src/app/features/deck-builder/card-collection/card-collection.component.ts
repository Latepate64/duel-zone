import { Component, Inject, EventEmitter, Output } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { DeckComponent } from './../deck/deck.component';

@Component({
  selector: 'app-card-collection',
  templateUrl: './card-collection.component.html'
})
export class CardCollectionComponent {
  public cards: Card[] = [];
  @Output() added = new EventEmitter<string>();
  deck: DeckComponent;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string, deck: DeckComponent) {
    http.get<Card[]>(baseUrl + 'card').subscribe(result => {
      this.cards = result;
    }, error => console.error(error));
    this.deck = deck;
  }

  public addCardToDeck(cardName: string) {
    this.deck.onAdded(cardName);
    //this.added.emit(cardName)
  }
}

interface Card {
  cardType: string;
  civilizations: string;
  manaCost: number;
  name: string;
  power: string;
  races: string;
  rulesText: string;
}

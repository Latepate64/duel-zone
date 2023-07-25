import { Component, Inject, EventEmitter, Output, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { DeckComponent } from './../deck/deck.component';
import { AuthService } from '@auth0/auth0-angular';
import { concatMap, tap, map } from 'rxjs/operators';

@Component({
  selector: 'app-card-collection',
  templateUrl: './card-collection.component.html'
})
export class CardCollectionComponent implements OnInit {
  public cards: Card[] = [];
  @Output() added = new EventEmitter<string>();
  deck : DeckComponent;
  metadata = {};

  constructor(public auth: AuthService, private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, deck: DeckComponent) {
    //http.get<Card[]>(baseUrl + 'card').subscribe(result => {
    //  this.cards = result;
    //}, error => console.error(error));
    this.deck = deck;
  }

  ngOnInit(): void {
    this.http.get<Card[]>(this.baseUrl + 'card').subscribe(result => {
     this.cards = result;
    }, error => console.error(error));
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

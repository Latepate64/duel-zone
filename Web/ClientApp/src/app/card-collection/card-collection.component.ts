import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-card-collection',
  templateUrl: './card-collection.component.html'
})
export class CardCollectionComponent {
  public cards: Card[] = [];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Card[]>(baseUrl + 'card').subscribe(result => {
      this.cards = result;
    }, error => console.error(error));
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

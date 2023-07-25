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
    this.auth.user$
      .pipe(
        concatMap((user) =>
          // Use HttpClient to make the call
          //this.http.get(
          //  encodeURI(`https://{yourDomain}/api/v2/users/${user?.sub}`)
          //)
          this.http.get<Card[]>(this.baseUrl + 'card/' + user?.sub)
        ),
        map((user: any) => user.user_metadata),
        tap((meta) => (this.metadata = meta))
      )
      .subscribe(result => {
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

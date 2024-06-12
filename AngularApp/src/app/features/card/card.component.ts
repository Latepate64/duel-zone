import { Component } from '@angular/core';

@Component({
  selector: 'app-card',
  templateUrl: './card.component.html',
  styleUrls: ['./card.component.css']
})
export class CardComponent {
  image = 'assets/cardback.png';

  mouseEnter() {
    this.image = 'assets/cardback.png'; //todo: could use different image
  }

  mouseLeave() {
    this.image = 'assets/cardback.png';
  }
}

import { Component } from '@angular/core';

@Component({
  selector: 'app-deck-builder-component',
  templateUrl: './deck-builder.component.html'
})
export class DeckBuilderComponent {
  public currentCount = 0;

  public incrementCounter() {
    this.currentCount++;
  }
}

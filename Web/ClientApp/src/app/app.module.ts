import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './shared/components/navigation/desktop/nav-menu/nav-menu.component';
import { HomeComponent } from './features/home/home.component';
import { DeckBuilderComponent } from './features/deck-builder/deck-builder.component';
import { CardCollectionComponent } from './features/deck-builder/card-collection/card-collection.component';
import { DeckComponent } from './features/deck-builder/deck/deck.component';
import { MatTableModule, MatTable, MatRow, MatTableDataSource } from '@angular/material/table';
import { AuthModule } from '@auth0/auth0-angular';
import { environment as env } from '../environments/environment';
import { SharedModule } from './shared'
import { AppRoutingModule } from './app-routing.module';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    DeckBuilderComponent,
    CardCollectionComponent,
    DeckComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    AppRoutingModule,
    MatTableModule,
    AuthModule.forRoot({
      ...env.auth0,
    }),
    SharedModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

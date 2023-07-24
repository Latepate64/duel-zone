import { Component } from '@angular/core';
import { AuthService } from "@auth0/auth0-angular";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {
  title = 'app';
  isAuth0Loading$ = this.authService.isLoading$;
  constructor(private authService: AuthService) { }
}

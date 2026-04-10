import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Header } from "./components/header/header";
import { HomeScreen } from "./components/home-screen/home-screen";
import { Login } from "./components/login/login";
import { WhyUsScreen } from "./components/why-us-screen/why-us-screen";
import { ContactScreen } from "./components/contact-screen/contact-screen";

@Component({
  standalone: true,
  selector: 'app-root',
 
  template: `
    <app-header [title]='siteTitle' ></app-header>
    <div class='main'>
      <router-outlet></router-outlet>
    </div>
  `,
  styles: `
    .main{
      margin:10px;
    }

  `,
  imports: [Header, HomeScreen, Login, WhyUsScreen, ContactScreen, RouterOutlet]
})
export class App {
  siteTitle="The Bank"
}

import { Component } from '@angular/core';
import { Products } from "../products/products";

@Component({
  selector: 'app-home-screen',
  imports: [Products],
  templateUrl: './home-screen.html',
  styleUrl: './home-screen.css',
})
export class HomeScreen {}

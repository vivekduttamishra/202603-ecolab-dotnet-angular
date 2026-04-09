import { Component, signal } from "@angular/core";
import { testComponent } from "./test.component";
import { ProductList } from "./products.component";
import { Product } from "../../data/product";
import { Likes } from "./likes.component";
import { Clock } from "./clock.component";


@Component({
    standalone:true,
    selector:'home-screen',
    template:`
        <!-- <app-test></app-test> -->
        

        <product-list></product-list>
    `,
    imports: [testComponent, ProductList, Likes, Clock]
})
export class HomeScreen{

  show=signal(true)

   handleToggle(){
      this.show.set(!this.show())
   }

}
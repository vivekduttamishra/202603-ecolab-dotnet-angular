import { Component, signal } from "@angular/core";
import { testComponent } from "./test.component";
import { ProductList } from "./products.component";
import { Product } from "../../data/product";


@Component({
    standalone:true,
    selector:'home-screen',
    template:`
        <!-- <app-test></app-test> -->
        <product-list></product-list>
    `,
    imports: [testComponent, ProductList]
})
export class HomeScreen{

   

}
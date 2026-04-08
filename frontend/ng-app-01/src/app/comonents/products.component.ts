import { Component, signal } from "@angular/core";
import { Product } from "../../data/product";
import { Card } from "./cart.component";
import { ProductService } from "../services/product.service";


@Component({

    selector: 'product-list',
    template: `
        <h2>Our Products</h2>

        <div class='row' >

            <img [hidden]='fetched()' [style.width.px]='180' [style.height.px]='180'  src='/loader07.gif' />

            @for(product of products(); track product.id){
                <div class="col">
                <utils-card
                    [title]='product.name'
                    [image]='product.coverImageUrl'
                    description={{product.description}}
                
                ></utils-card>
            </div>
            }
        </div>
            

    `,
    styles: `
       
    
    `,
    imports: [Card]


})
export class ProductList {

    products = signal<Product[]>([]);
    fetched=signal(false);
    
    //service=new ProductService();
    
    constructor(private service:ProductService){
        this.fetchProducts();
    }
    
    async fetchProducts(){
        let products = await this.service.getAllProducts();
        this.products.set(products);
        this.fetched.set(true);
    }
    

}
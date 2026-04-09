import { Component, signal } from "@angular/core";
import { Product } from "../../data/product";
import { Card } from "./cart.component";
import { ProductService } from "../services/product.service";


@Component({

    selector: 'product-list-v1',
    template: `
        <h2>Our Products</h2>

        <div class='row' >


            <img [hidden]='fetched()' [style.width.px]='180' [style.height.px]='180'  src='/loader07.gif' />
            <div class='range'>
                <button class='btn'
                    (click)="handleColumnChange(-1)"
                    [disabled]="selectedOption()===1"
                >⬇️</button>
                {{selectedOption()}}
                <button class='btn'
                    (click)="handleColumnChange(1)"
                    [disabled]="selectedOption()===4"
                >⬆️</button>
            </div>
            @for(product of products(); track product.id){
                <div class="col {{options[selectedOption()]}}">
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
       .range{
         font-size:18px;
       }
       .range button{
        font-size:18px;
       }
    
    `,
    imports: [Card]


})
export class ProductList {

    products = signal<Product[]>([]);
    fetched=signal(false);
    selectedOption=signal(2)
    options=['', 'col-12','col-6', 'col-4', 'col-3']

    handleColumnChange(delta:number){
        let value = this.selectedOption()+delta;
        if(value>=1 && value<=4)
            this.selectedOption.set(value)
    }
    
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
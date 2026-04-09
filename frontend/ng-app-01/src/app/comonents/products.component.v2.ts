import { Component, signal } from "@angular/core";
import { Product } from "../../data/product";
import { Card } from "./cart.component";
import { ProductService } from "../services/product.service";
import { ChangeInfo, Range } from "./range.component";


@Component({
    selector: 'product-list',
    template: `
        <h2>Our Products</h2>

        <div class='row' >
            <img [hidden]='fetched()' [style.width.px]='180' [style.height.px]='180'  src='/loader07.gif' />
        
            <util-range 
                [value]='selectedOption()'  [min]='1'  [max]='4' 
                
                (change) = 'handleChange($event)'    
            >

            </util-range>
        
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
    imports: [Card, Range]


})
export class ProductList {

   
    selectedOption=signal(2)
    options=['', 'col-12','col-6', 'col-4', 'col-3']


    handleChange(info:ChangeInfo){

        //console.log('info',info);
        this.selectedOption.set(info.updated)
        
    }



    
    //service=new ProductService();

    products = signal<Product[]>([]);
    fetched=signal(false);
    
    constructor(private service:ProductService){
        this.fetchProducts();
    }
    
    async fetchProducts(){
        let products = await this.service.getAllProducts();
        this.products.set(products);
        this.fetched.set(true);
    }
    

}
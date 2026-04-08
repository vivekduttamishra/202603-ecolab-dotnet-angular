import { Component, signal } from "@angular/core";
import { Product } from "../../data/product";


@Component({

    selector: 'product-list',
    template: `
        <h2>Our Products</h2>

        <div class='row' >
            @for(product of products(); track product.name){
                <div class="card" style="width: 18rem;">
                <img src="{{product.coverImageUrl}}" class="card-img-top" alt={{product.name}}>
                <div class="card-body">
                    <h5 class="card-title">{{product.name}}</h5>
                    <p class="card-text">{{product.description}}</p>
                    <a href="#" class="btn btn-primary">Details</a>
                </div>
                </div>
            }
        </div>
            

    `,
    styles:`
        .card{
           margin:5px; 
        }
        img{
            max-height: 150px;
            height:150px;
            width:100% !important;
        }
    
    `


})
export class ProductList {

    products = signal<Product[]>([
        {
            id: 1,
            coverImageUrl: "/savings-account.jpg",
            name: "Savings Account",
            description: "Your money earns for you"
        },
        {
            id: 2,
            coverImageUrl: "/current-account.jpg",
            name: "Current Account",
            description: "Your Business needs me"
        },
        {
            id: 3,
            coverImageUrl: "/overdraft-account.jpg",
            name: "Overdraft Account",
            description: "Never run out of Balance!"
        },
        {
            id: 4,
            coverImageUrl: "/credit-card.jpg",
            name: "Credit Cards",
            description: "Spending can be rewarding"
        },

    ]);

}
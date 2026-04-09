import { Product } from "../../data/product";
import { delay } from "../utils/delay";


export class ProductService{
    products : Product[]=[
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

    ];

    async getAllProducts(){
        await delay(300) //simulated delay
        return this.products;
    }

    async getProductById(id:number){
        await delay(2000) //simulated delay
        return this.products.find(p=>p.id===id)
    }


}
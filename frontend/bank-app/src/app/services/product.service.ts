import { Observable, of, delay, takeUntil, interval, map, take, tap } from "rxjs";

export interface Product{

    id:string|number,
    name:string,
    coverImageUrl:string,
    description:string

}

export class ProductService{
    products : Product[]=[
        {
            id: 1,
            coverImageUrl: "/savings-account.jpg",
            name: "Savings Account",
            description: "Your money earns for you and it is a great way to save the money for your future"
        },
        {
            id: 2,
            coverImageUrl: "/current-account.jpg",
            name: "Current Account",
            description: "Your Business needs me. We offer unlimited transaction and real time support"
        },
        {
            id: 3,
            coverImageUrl: "/overdraft-account.jpg",
            name: "Overdraft Account",
            description: "Never run out of Balance! You can withdraw more than what you have got. You get low rate of interest on overdraft"
        },
        {
            id: 4,
            coverImageUrl: "/credit-card.jpg",
            name: "Credit Cards",
            description: "Spending can be rewarding. Enjoy multiple life-style benefits and parner rewards when you spent the money."
        },

    ];

    async getAllProducts(){
        await delay(2000) //simulated delay
        return this.products;
    }

    getProductsObservable(){

        return interval(1000)
                .pipe(
                   // tap(x=>console.log('got',x)),
                    map(n=>this.products[n]),
                  // map(p=> ({...p, description: p.description.substring(0,40) })),
                  //  tap(x=> console.log('after map',x)),
                    take(this.products.length)
                )
    }

    async getProductById(id:number){
        await delay(2000) //simulated delay
        return this.products.find(p=>p.id===id)
    }


}
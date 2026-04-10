import { Component, signal } from '@angular/core';
import { Product, ProductService } from '../../services/product.service';
import { Range } from "../utils/range";
import { Card } from "../utils/card";
import { CommonModule } from '@angular/common';
import { TrimPipe } from '../../pipes/utils/trim-pipe';

@Component({
  selector: 'app-products',
  imports: [Range, Card, CommonModule, TrimPipe],
  templateUrl: './products.html',
  styleUrl: './products.css',
})
export class Products {

  stockPrice=133

  selectedOption = signal(2)
  options = ['', 'col-12', 'col-6', 'col-4', 'col-3']




  //service=new ProductService();

  products = signal<Product[]>([]);
  fetched = signal(false);

  constructor(private service: ProductService) {
    this.fetchProducts();
  }

  async fetchProducts() {
     this
      .service
      .getProductsObservable()
      .subscribe({
        next: product=>{
           this.products.set([...this.products(), product])
           
        },
        error: error=> console.log('error',error),
        complete: ()=>  this.fetched.set(true)

      }


      )
  }

}

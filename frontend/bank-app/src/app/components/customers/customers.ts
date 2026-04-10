import { Component, inject, signal } from '@angular/core';
import { Customer, CustomerService } from '../../services/customer.service';
import { RouterLink } from '@angular/router';
import { EmailEncoderPipe } from '../../pipes/utils/email-encoder-pipe';

@Component({
  selector: 'app-customers',
  imports: [RouterLink, EmailEncoderPipe],
  templateUrl: './customers.html',
  styleUrl: './customers.css',
})
export class Customers {

    // constructor(private service: CustomerService){

    // }

    service = inject(CustomerService)

    customers=signal<Customer[]>([])
    fetched=signal(false);
    error=signal<any>(null)

    ngOnInit(){
      this.getCustomers();
    }

    getCustomers(){
      this
        .service
        .getAllCustomers()
        .subscribe({
          next: customers=>{
            this.customers.set(customers)
            this.fetched.set(true)
          }, 
            
          error: error=> this.error.set(error)
          
        })
    }


}

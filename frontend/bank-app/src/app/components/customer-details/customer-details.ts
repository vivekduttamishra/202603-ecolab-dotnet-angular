import { Component, effect, inject, signal } from '@angular/core';
import { ActivatedRoute, Router  } from '@angular/router';
import { Customer, CustomerService } from '../../services/customer.service';
import { NotFound } from "../utils/not-found";
import { HttpErrorResponse } from '@angular/common/http';
import { CustomerInfo } from "../customer-info/customer-info";

@Component({
  selector: 'app-customer-details',
  imports: [CustomerInfo],
  template: `<app-customer-info [customer]='customer()' [error]='error()'>
            </app-customer-info>`,
  styleUrl: './customer-details.css',
})
export class CustomerDetails {

  router=inject(Router)
  route = inject(ActivatedRoute)
  service = inject(CustomerService)
  customer=signal<Customer|null>(null)
  error=signal<HttpErrorResponse|null>(null)
  


  constructor() {
    effect(() => {
      this.route.queryParamMap.subscribe({
        next: (query) => {
          var email = query.get("email")
          if(!email)
            return this.router.navigate(['/customers']);
            
          this.fetchCustomer(email) //i know email will be passed
          return 
        }
      })
    })
  }

  fetchCustomer(email: string) {
    
    this
      .service
      .getCustomerByEmail(email)
      .subscribe({

        next: customer=>{
          this.customer.set(customer)
        },
        error: error=>{
          this.error.set(error)
          console.log('error',error)
        }

      })
  }

}

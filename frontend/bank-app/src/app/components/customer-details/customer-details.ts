import { Component, effect, inject, signal } from '@angular/core';
import { ActivatedRoute, ParamMap } from '@angular/router';
import { Customer, CustomerService } from '../../services/customer.service';
import { NotFound } from "../utils/not-found";
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-customer-details',
  imports: [NotFound],
  templateUrl: './customer-details.html',
  styleUrl: './customer-details.css',
})
export class CustomerDetails {

  route = inject(ActivatedRoute)
  service = inject(CustomerService)
  customer=signal<Customer|null>(null)
  error=signal<HttpErrorResponse|null>(null)
  


  constructor() {
    effect(() => {
      this.route.paramMap.subscribe({
        next: (params) => {
          this.fetchCustomer(params.get("email")!) //i know email will be passed
        }
      })
    })
  }

  fetchCustomer(email: string) {
    //email=email.replace('-at-','@')
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

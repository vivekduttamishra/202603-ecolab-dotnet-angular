import { Component, effect, inject, signal } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Customer, CustomerService } from '../../services/customer.service';
import { HttpErrorResponse } from '@angular/common/http';
import { CustomerInfo } from "../customer-info/customer-info";

@Component({
  selector: 'app-customer-by-id',
  imports: [CustomerInfo],
  template: `
    <app-customer-info  [customer]="customer()" [error]='error()'  ></app-customer-info>
  
  `,
  styleUrl: './customer-by-id.css',
})
export class CustomerById {

  route= inject(ActivatedRoute)
  customerService= inject(CustomerService)
  customer=signal<Customer|null>(null)
  error=signal<HttpErrorResponse|null>(null)

  constructor(){
    effect(()=>{
      this.route.paramMap.subscribe({
        next: path=> {
          const id = path.get('id')!
          this.fetchCustomer(Number(id))
        }
      })
    })
  }

  fetchCustomer(id: number) {
    this.customerService
        .getCustomerById(id)
        .subscribe({
          next: customer=> this.customer.set(customer),
          error:error=> this.error.set(error)
        })
  }



}

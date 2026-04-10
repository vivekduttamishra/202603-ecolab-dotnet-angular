import { Component, input } from '@angular/core';
import { Customer } from '../../services/customer.service';
import { HttpErrorResponse } from '@angular/common/http';
import { NotFound } from '../utils/not-found';

@Component({
  selector: 'app-customer-info',
  imports: [NotFound],
  templateUrl: './customer-info.html',
  styleUrl: './customer-info.css',
})
export class CustomerInfo {

  customer=input<Customer|null>(null)
  error=input<HttpErrorResponse|null>(null)


}

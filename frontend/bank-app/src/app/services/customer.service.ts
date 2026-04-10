import { HttpClient } from "@angular/common/http"
import { inject, Injectable } from "@angular/core"
import { Observable, of, tap } from "rxjs"


export interface Customer {
    id:number,
    name: string,
    email: string,
    address: string,
    isActive: boolean,
    photo: string | null,
    phone: string | null,
    account?: any[]
}

const baseUrl = 'http://localhost:8000/api/customers'


@Injectable({ providedIn: "root" })
export class CustomerService {
    login(email: string, password: string) {
      return this.http
                .post('http://localhost:8000/api/auth/login', { email, password })
                .pipe()
    }

    http = inject(HttpClient)

    getAllCustomers(): Observable<Customer[]> {

        return this
            .http
            .get<Customer[]>(baseUrl)
            .pipe(
                tap((x) => console.log(x))
            )
    }
    getCustomerByEmail(email: string) {

        return this.http
            .get<Customer>(`${baseUrl}/info?email=${email}`)
            .pipe()


    }


    getCustomerById(id:number) {

        return this.http
            .get<Customer>(`${baseUrl}/${id}`)
            .pipe()    
    }



    async getAllCustomersAsync(): Promise<Customer[]> {
        const response = await fetch(baseUrl)
        const customers = await response.json()
        return customers
    }


}
import { HttpClient } from "@angular/common/http"
import { inject, Injectable } from "@angular/core"
import { Observable, of, tap } from "rxjs"


export interface Customer {
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
            .get<Customer>(`${baseUrl}/${email}`)
            .pipe()


    }



    async getAllCustomersAsync(): Promise<Customer[]> {
        const response = await fetch(baseUrl)
        const customers = await response.json()
        return customers
    }


}
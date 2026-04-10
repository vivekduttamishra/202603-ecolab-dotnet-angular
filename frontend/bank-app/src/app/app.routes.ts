import { Routes } from '@angular/router';
import { Products } from './components/products/products';
import { WhyUsScreen } from './components/why-us-screen/why-us-screen';
import { ContactScreen } from './components/contact-screen/contact-screen';
import { Login } from './components/login/login';
import { NewCustomer } from './components/new-customer/new-customer';
import { NotFound } from './components/utils/not-found';
import { Customers } from './components/customers/customers';
import { CustomerDetails } from './components/customer-details/customer-details';

export const routes: Routes = [

    {
        path:"",
        pathMatch:'full',
        redirectTo:"/products"
    },

    {
        path:"products",
        component: Products        
    },
    {
        path:"why-us",
        component: WhyUsScreen
    },
    {
        path:"contact-us",
        component:ContactScreen
    },
    {
        path:"login",
        component:Login
    },
    {
        path:"new-customer",
        component:NewCustomer
    },
    {
        path:"customers",
        component:Customers
    },
    {
        path:"customers/:email",
        component: CustomerDetails
    },
    {
        path:"**",
        component: NotFound
    }



];

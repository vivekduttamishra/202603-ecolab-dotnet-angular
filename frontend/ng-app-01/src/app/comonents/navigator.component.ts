import { Component } from "@angular/core";


@Component({
    standalone: true,
    selector: 'app-navigator',
    template: `
        <nav>
            <a href="/new">New Customer</a>
            <a href="/login">Login</a>
            <a href="/contact">Contact Us</a>
        </nav>

    `
})
export class Naivator {

}
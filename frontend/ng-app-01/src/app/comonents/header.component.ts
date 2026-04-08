import { Component } from "@angular/core";
import { Clock } from "./clock.component";
import { Naivator } from "./navigator.component";


@Component({
    standalone: true, //not part of module
    selector: 'app-header',
    template: `
    <div>
        <h1>Universal Bank</h1>
        <app-navigator></app-navigator>
        <util-clock></util-clock>
    </div>    
    `,
    imports: [Clock, Naivator]
})
export class Header {

}
import { Component, input } from '@angular/core';

@Component({
  selector: 'utils-card',
  imports: [],
  template: ` 
  <div class="card" style="width: 18rem;">
      <img src="{{image()}}" class="card-img-top" alt={{title()}}>
      <div class="card-body">
          <h5 class="card-title">{{title()}}</h5>
          <p class="card-text">{{description()}}</p>
          <a [hidden]='link()===undefined' [href]='link()' class="btn btn-primary">linkText()</a>
      </div>
      </div>
  
  `,
  styles: ``,
})
export class Card {

  title = input<string>()
  image = input<string>()
  description = input<string>()
  link = input<string | undefined>()
  linkText = input("Details")

}

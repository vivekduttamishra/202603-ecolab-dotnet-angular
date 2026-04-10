import { Component, inject, signal } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CustomerService } from '../../services/customer.service';

@Component({
  selector: 'app-login',
  imports: [FormsModule],
  templateUrl: './login.html',
  styleUrl: './login.css',
})
export class Login {

  email=signal('')
  password=signal('')
  customerService = inject(CustomerService)
  wait=signal(false)
  error=signal<any>(null)

  async handleLogin() {
    console.log('this.email()',this.email());
    console.log('this.password()',this.password());
    if(this.email() && this.password()){
      this.wait.set(true)
      this.customerService
          .login(this.email(), this.password())
          .subscribe({
            next: response=>{
              //token
              console.log('response',response)
              this.wait.set(false)
            },
            error: error=>{
              console.log('error',error)
              this.error.set(error)
              this.wait.set(false)
            }
          })
    }
  }
}

import { Component, input, signal } from '@angular/core';
import { Membership } from "../membership/membership";
import { RouterLink } from '@angular/router';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-header',
  imports: [Membership, RouterLink, DatePipe],
  templateUrl: './header.html',
  styleUrl: './header.css',
})
export class Header {

  title=input('Site Title')
  date=new Date()
}

import { Component, signal } from '@angular/core';
import { OrderService } from '../../../core/services/order-service';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-checkout',
  imports: [FormsModule,CommonModule],
  templateUrl: './checkout.html',
  styleUrl: './checkout.css',
})
export class Checkout {
 paymentMethod = signal('UPI');
  result = signal<any>(null);

  constructor(private service: OrderService) {}

  placeOrder() {

    const data = {
      userName: 'devira',
      paymentMethod: this.paymentMethod()
    };

    this.service.checkout(data).subscribe(res => {
      this.result.set(res);
    });
  }
}

import { Component, signal } from '@angular/core';
import { CartService } from '../../../core/services/cart-service';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-cart',
  imports: [FormsModule,CommonModule],
  templateUrl: './cart.html',
  styleUrl: './cart.css',
})
export class Cart {

  cartItems = signal<any[]>([]);
  validation = signal<any>(null);

  userName = 'devira';

  constructor(private service: CartService) {}

  ngOnInit(): void {
    this.load();
  }

  load() {
    this.service.get(this.userName).subscribe(res => {
      this.cartItems.set(res);
    });

    this.service.validate(this.userName).subscribe(res => {
      this.validation.set(res);
    });
  }

  remove(id: number) {
    this.service.delete(id).subscribe(() => {
      this.load();
    });
  }

  checkout() {
    alert('Checkout Success');
  }

}

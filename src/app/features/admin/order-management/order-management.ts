import { Component, signal } from '@angular/core';
import { OrderService } from '../../../core/services/order-service';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-order-management',
  imports: [FormsModule,CommonModule],
  templateUrl: './order-management.html',
  styleUrl: './order-management.css',
})
export class OrderManagement {
 orders = signal<any[]>([]);

  constructor(private service: OrderService) {}

  ngOnInit(): void {
    this.load();
  }

  load() {
    this.service.getAllOrders().subscribe(res => {
      this.orders.set(res);
    });
  }

  filter(status: string) {
    this.service.getByStatus(status).subscribe(res => {
      this.orders.set(res);
    });
  }

  update(id: number, status: string) {

    const data = {
      orderId: id,
      status: status
    };

    this.service.updateStatus(data).subscribe(() => {
      this.load();
    });
  }
}

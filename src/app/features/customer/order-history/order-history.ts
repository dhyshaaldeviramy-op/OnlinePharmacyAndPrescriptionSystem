import { Component, signal } from '@angular/core';
import { HistoryService } from '../../../core/services/history-service';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-order-history',
  imports: [FormsModule,CommonModule],
  templateUrl: './order-history.html',
  styleUrl: './order-history.css',
})
export class OrderHistory {
orders = signal<any[]>([]);

  constructor(private service: HistoryService) {}

  ngOnInit(): void {
    this.service.get('devira').subscribe(res => {
      this.orders.set(res);
    });
  }
}

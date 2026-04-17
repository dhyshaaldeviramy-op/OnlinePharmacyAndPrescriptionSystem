import { CartService } from './../../../core/services/cart-service';
import { Component } from '@angular/core';
import { MedicineService } from '../../../core/services/medicine-service';
import { debounceTime, Subject } from 'rxjs';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-medicine-search',
  imports: [FormsModule,CommonModule,RouterModule],
  templateUrl: './medicine-search.html',
  styleUrl: './medicine-search.css',
})
export class MedicineSearch {
  searchText = '';
  medicines: any[] = [];

  searchSubject = new Subject<string>();

  constructor(private service: MedicineService, private cartService: CartService) {
    this.searchSubject.pipe(
      debounceTime(500) // ⏱ wait 0.5 sec
    ).subscribe(value => {
      this.loadResults(value);
    });
  }
ngOnInit() {
  this.service.getAll().subscribe(res => {

    const updated = res.map((x:any) => ({
      ...x,
      quantity: 1
    }));

    this.medicines = updated;

  });
}
 addToCart(item: any) {

  const qty = item.quantity || 1;

  const data = {
    medicineId: item.id,
    userName: 'devira',
    quantity: qty
  };

  this.cartService.add(data).subscribe({
    next: () => alert('Added to Cart'),
    error: err => console.log(err)
  });
}
  onSearchChange() {
    this.searchSubject.next(this.searchText);
  }

  loadResults(term: string) {
    if (!term) {
      this.medicines = [];
      return;
    }

    this.service.search(term).subscribe(res => {
      this.medicines = res;
    });
  }
}

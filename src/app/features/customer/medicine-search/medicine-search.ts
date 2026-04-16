import { Component } from '@angular/core';
import { MedicineService } from '../../../core/services/medicine-service';
import { debounceTime, Subject } from 'rxjs';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-medicine-search',
  imports: [FormsModule,CommonModule],
  templateUrl: './medicine-search.html',
  styleUrl: './medicine-search.css',
})
export class MedicineSearch {
  searchText = '';
  medicines: any[] = [];

  searchSubject = new Subject<string>();

  constructor(private service: MedicineService) {
    this.searchSubject.pipe(
      debounceTime(500) // ⏱ wait 0.5 sec
    ).subscribe(value => {
      this.loadResults(value);
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

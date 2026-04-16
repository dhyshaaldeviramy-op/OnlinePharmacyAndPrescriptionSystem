import { Component } from '@angular/core';
import { MedicineService } from '../../../../core/services/medicine-service';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-medicine-catalog',
  imports: [FormsModule,CommonModule],
  templateUrl: './medicine-catalog.html',
  styleUrl: './medicine-catalog.css',
})
export class MedicineCatalog {

  medicines: any[] = [];

  form: any = {
    name: '',
    manufacturer: '',
    category: '',
    price: 0,
    stock: 0,
    expiryDate: '',
    isPrescriptionRequired: false
  };

  constructor(private service: MedicineService) {}

  ngOnInit() {
    this.load();
  }

  load() {
    this.service.getAll().subscribe(res => {
      this.medicines = res;
    });
  }

  save() {
    this.service.add(this.form).subscribe(() => {
      alert('Added Successfully');
      this.load();
    });
  }

  delete(id: number) {
    this.service.delete(id).subscribe(() => {
      this.load();
    });
  }
}


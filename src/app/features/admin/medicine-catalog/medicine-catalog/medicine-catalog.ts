import { Component, signal } from '@angular/core';
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

  medicines = signal<any[]>([]);

  selectedId = 0;

  model:any = {
    name:'',
    manufacturer:'',
    category:'',
    price:0,
    stock:0,
    expiryDate:'',
    isPrescriptionRequired:false
  };

  constructor(private service: MedicineService) {}

  ngOnInit(): void {
    this.load();
  }

  load() {
    this.service.getAll().subscribe(res => {
      this.medicines.set(res);
    });
  }

  addMedicine() {
    this.service.add(this.model).subscribe(() => {
      alert('Medicine Added');
      this.resetForm();
      this.load();
    });
  }

  edit(item:any) {
    this.model = { ...item };
    this.selectedId = item.id;
  }

  updateMedicine() {
    this.service.update(this.selectedId, this.model)
      .subscribe(() => {
        alert('Updated Successfully');
        this.resetForm();
        this.load();
      });
  }

  delete(id:number) {
    this.service.delete(id).subscribe(() => {
      this.load();
    });
  }

  resetForm() {
    this.selectedId = 0;

    this.model = {
      name:'',
      manufacturer:'',
      category:'',
      price:0,
      stock:0,
      expiryDate:'',
      isPrescriptionRequired:false
    };
  }
}
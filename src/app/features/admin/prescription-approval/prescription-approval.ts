import { Component, signal } from '@angular/core';
import { PrescriptionService } from '../../../core/services/prescription-service';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-prescription-approval',
  imports: [FormsModule,CommonModule],
  templateUrl: './prescription-approval.html',
  styleUrl: './prescription-approval.css',
})
export class PrescriptionApproval {
 

  prescriptions = signal<any[]>([]);

  constructor(private service: PrescriptionService) {}

  ngOnInit(): void {
    this.load();
  }

  load() {
    this.service.getAll().subscribe(res => {
      this.prescriptions.set(res);
    });
  }

  approve(id: number) {
    this.service.approve(id).subscribe(() => {
      this.load();
    });
  }

  reject(id: number) {
    const reason = prompt('Enter reject reason');

    if (reason) {
      this.service.reject(id, reason).subscribe(() => {
        this.load();
      });
    }
  }

}

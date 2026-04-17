import { Component, signal } from '@angular/core';
import { AlertService } from '../../../core/services/alert-service';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-alert',
  imports: [FormsModule,CommonModule],
  templateUrl: './alert.html',
  styleUrl: './alert.css',
})
export class Alert {
  data = signal<any>(null);

  constructor(private service: AlertService) {}

  ngOnInit(): void {
    this.service.get().subscribe(res => {
      this.data.set(res);
    });
  }
}

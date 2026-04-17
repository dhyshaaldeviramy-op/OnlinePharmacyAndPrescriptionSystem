import { Component, signal } from '@angular/core';
import { DashboardService } from '../../../core/services/dashboard-service';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-dashboard',
  imports: [FormsModule,CommonModule],
  templateUrl: './dashboard.html',
  styleUrl: './dashboard.css',
})
export class Dashboard {
 stats = signal<any>(null);

  constructor(private service: DashboardService) {}

  ngOnInit(): void {
    this.service.getStats().subscribe(res => {
      this.stats.set(res);
    });
  }
}

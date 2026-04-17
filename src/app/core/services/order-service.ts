import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class OrderService {
  api = 'https://localhost:7257/api';

  constructor(private http: HttpClient) {}

  checkout(data: any) {
    return this.http.post(`${this.api}/Order/checkout`, data);
  }

  getAllOrders() {
    return this.http.get<any[]>(`${this.api}/OrderWorkflow`);
  }

  getByStatus(status: string) {
    return this.http.get<any[]>(
      `${this.api}/OrderWorkflow/status/${status}`
    );
  }

  updateStatus(data: any) {
    return this.http.put(
      `${this.api}/OrderWorkflow/update-status`,
      data
    );
  }
}

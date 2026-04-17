import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class DashboardService {

  api = 'https://localhost:7257/api/Dashboard';

  constructor(private http: HttpClient) {}

  getStats() {
    return this.http.get<any>(this.api);
  }  
}

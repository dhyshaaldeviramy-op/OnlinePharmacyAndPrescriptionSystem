import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class HistoryService {
   api = 'https://localhost:7257/api/OrderHistory';

  constructor(private http: HttpClient) {}

  get(userName: string) {
    return this.http.get<any[]>(`${this.api}/${userName}`);
  }
}

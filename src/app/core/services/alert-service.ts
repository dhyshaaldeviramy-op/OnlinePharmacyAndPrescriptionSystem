import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class AlertService {
  
  api = 'https://localhost:7257/api/Alert';

  constructor(private http: HttpClient) {}

  get() {
    return this.http.get<any>(this.api);
  }
}

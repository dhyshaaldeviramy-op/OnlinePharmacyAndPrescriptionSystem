import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class FeedbackService {
  
  api = 'https://localhost:7257/api/Feedback';

  constructor(private http: HttpClient) {}

  add(data: any) {
    return this.http.post(this.api, data);
  }

  getAll() {
    return this.http.get<any[]>(this.api);
  }
}

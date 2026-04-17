import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class CartService {
  
  api = 'https://localhost:7257/api/cart';

  constructor(private http: HttpClient) {}

  add(data: any) {
    return this.http.post(this.api, data);
  }

  get(userName: string) {
    return this.http.get<any[]>(`${this.api}/${userName}`);
  }

  delete(id: number) {
    return this.http.delete(`${this.api}/${id}`);
  }

  validate(userName: string) {
    return this.http.get<any>(`${this.api}/validate/${userName}`);
  }
}

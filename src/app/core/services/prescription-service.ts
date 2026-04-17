import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class PrescriptionService {

   api = 'https://localhost:7257/api/prescription';
   constructor(private http: HttpClient) {}
upload(file: File, userName: string) {
  const formData = new FormData();
  formData.append('file', file);

  return this.http.post(
    `${this.api}/upload?userName=${userName}`,
    formData,
    { responseType: 'text' }
  );
}

  getAll() {
    return this.http.get<any[]>(this.api);
  }

  approve(id: number) {
    return this.http.put(`${this.api}/approve/${id}`, {});
  }

  reject(id: number, reason: string) {
    return this.http.put(
      `${this.api}/reject/${id}?reason=${reason}`,
      {}
    );
  }
}

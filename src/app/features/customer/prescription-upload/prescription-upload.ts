import { Component } from '@angular/core';
import { PrescriptionService } from '../../../core/services/prescription-service';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-prescription-upload',
  standalone: true,
  imports: [FormsModule,CommonModule],
  templateUrl: './prescription-upload.html',
  styleUrl: './prescription-upload.css',
})
export class PrescriptionUpload {
 selectedFile!: File;
  userName = '';

  constructor(private service: PrescriptionService) {}

  onFileChange(event: any) {
    this.selectedFile = event.target.files[0];
  }

  upload() {
    if (!this.selectedFile || !this.userName) {
      alert('Enter username and choose file');
      return;
    }

    this.service.upload(this.selectedFile, this.userName)
      .subscribe(() => {
        alert('Uploaded Successfully');
      });
  }
}

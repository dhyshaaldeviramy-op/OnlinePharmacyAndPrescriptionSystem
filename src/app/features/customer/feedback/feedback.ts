import { Component, signal } from '@angular/core';
import { FeedbackService } from '../../../core/services/feedback-service';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-feedback',
  imports: [FormsModule,CommonModule],
  templateUrl: './feedback.html',
  styleUrl: './feedback.css',
})
export class Feedback {

  model = {
    userName: 'devira',
    medicineId: 1,
    rating: 5,
    comment: ''
  };

  message = signal('');

  constructor(private service: FeedbackService) {}

  submit() {
    this.service.add(this.model).subscribe(() => {
      this.message.set('Feedback Submitted Successfully');
      this.model.comment = '';
    });
  }
}

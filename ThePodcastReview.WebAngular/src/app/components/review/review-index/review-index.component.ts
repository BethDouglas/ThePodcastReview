import { Component, OnInit } from '@angular/core';
import { ReviewService } from '../../../services/review.service';
import { Review } from '../../../models/review';
import { DataSource } from '@angular/cdk/collections';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/of';

@Component({
  selector: 'app-review-index',
  templateUrl: './review-index.component.html',
  styleUrls: ['./review-index.component.css']
})
export class ReviewIndexComponent implements OnInit {
  review: Review[];
  columnNames = ['ReviewId', 'PodcastTitle', 'Rating', 'CreatedUtc', 'buttons'];
  dataSource: ReviewDataSource | null;

  constructor(private _reviewService: ReviewService) { }

  ngOnInit() {
    this._reviewService.getReview().subscribe((review: Review[]) => {
      this.dataSource = new ReviewDataSource(review);
    });
  }
}

export class ReviewDataSource extends DataSource<any>
 {
   constructor(private reviewData: Review[]) {
     super();
   }

   connect(): Observable<Review[]> {
     return Observable.of(this.reviewData);
   }

   disconnect() { }
 }
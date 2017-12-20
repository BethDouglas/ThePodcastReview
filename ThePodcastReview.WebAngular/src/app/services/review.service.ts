import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

const ApiUrl = 'http://localhost:60311';

@Injectable()
export class ReviewService {

  constructor(private _http: HttpClient) { }

  getReview() {
    return this._http.get(`${ApiUrl}/Review`, { headers: this.getHeaders() });
  }

  private getHeaders() {
    return new HttpHeaders().set('Authorization', `Bearer ${localStorage.getItem('id_token')}`);
  }
}

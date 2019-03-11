import { Injectable } from '@angular/core';
import { Http } from '@angular/http';

@Injectable({
  providedIn: 'root'
})
export class StudentsService {

  private url = 'https://localhost:5001/api/students';

  constructor(private http: Http) { }

  getStudents() {
    return this.http.get(this.url);
  }
}

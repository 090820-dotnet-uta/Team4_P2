import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Course } from './course';

@Injectable({
  providedIn: 'root'
})
export class CourseService {

  private coursesURL = 'localhost:5001/api/Course/GetAll'; // URL to web api

  constructor(
    private http: HttpClient
  ) { }

  // GET Methods
  getCourses(): Observable<Course[]> {
    return this.http.get<Course[]>(this.coursesURL);
  }
}

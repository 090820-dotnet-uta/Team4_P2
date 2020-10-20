import { Component, OnInit } from '@angular/core';
import { Course } from '../course';
import { CourseService } from '../course.service';

@Component({
  selector: 'app-courses',
  templateUrl: './courses.component.html',
  styleUrls: ['./courses.component.css']
})
export class CoursesComponent implements OnInit {

  // Declare courses as an array of courses
  courses: Course[];
  constructor(private courseService: CourseService) { }

  ngOnInit(): void {
    this.getCourses();
  }

  // Function to get list of courses
  getCourses(): void {
    this.courseService.getCourses()
    .subscribe(courses => this.courses = courses);
  }

}

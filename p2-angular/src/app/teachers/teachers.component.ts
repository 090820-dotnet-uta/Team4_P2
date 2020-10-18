import { Component, OnInit } from '@angular/core';
import { Teacher } from '../teacher';

@Component({
  selector: 'app-teachers',
  templateUrl: './teachers.component.html',
  styleUrls: ['./teachers.component.css']
})
export class TeachersComponent implements OnInit {
  teachers: Teacher[];
  constructor() { }

  ngOnInit(): void {
  }

}

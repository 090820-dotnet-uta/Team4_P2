import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TeachersComponent } from './teachers/teachers.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { StudentsComponent } from './students/students.component';
import { CoursesComponent } from './courses/courses.component';

const routes: Routes = [
  { path: '', redirectTo: '/dashboard', pathMatch: 'full'},
  { path: 'teachers', component: TeachersComponent },
  { path: 'students', component: StudentsComponent },
  { path: 'courses', component: CoursesComponent },
  { path: 'dashboard', component: DashboardComponent }
];

@NgModule({
  declarations: [],
  imports: [ RouterModule.forRoot(routes)],
  exports: [ RouterModule ]
})
export class AppRoutingModule { }

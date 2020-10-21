using System;
using System.Collections.Generic;
using Team4_P2.Repo.Data;
using System.Threading.Tasks;
using Team4_P2.Models;
using Microsoft.EntityFrameworkCore;
using Team4_P2.Models.Models;

namespace Team4_P2.Repo.Repository
{
    public class Repository
    {
        private readonly AppDbContext _context;
        public Repository(AppDbContext context)
        {
            _context = context;
        }
        //Each object needs a GetAll, a get singular record, an add record, an edit record, and a delete record

        //Admin crud
        public async Task<List<Admin>> GetAdminsAsync()
        {
            return await _context.Admins.ToListAsync();
        }
        public async Task<Admin> GetAdminAsync(int assignmentId)
        {
            return await _context.Admins.FirstOrDefaultAsync(Admin => Admin.AdminId == assignmentId);
        }
        public async Task<Admin> AddAdmin(Admin admin)
        {
            _context.Add(admin);
            _context.SaveChanges();
            return await _context.Admins.FirstOrDefaultAsync(tempAdmin => tempAdmin.Equals(admin));
        }
        public async Task<Admin> EditAdminScoreAsync(Admin admin)
        {
            var Admin = await _context.Admins.FirstOrDefaultAsync(x => x.AdminId == admin.AdminId);
            Admin = admin;
            _context.Update(Admin);
            _context.SaveChanges();
            return await _context.Admins.FirstOrDefaultAsync(x => x == admin);
        }
        public async Task<Boolean> DeleteAdmin(int assignmentId)
        {
            try
            {
                var Admin = await _context.Assignments.FirstOrDefaultAsync(Admin => Admin.AssignmentID == assignmentId);
                _context.Remove(Admin);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }
        //assignment crud
        public async Task<List<Assignment>> GetAssignmentsAsync()
        {
            return await _context.Assignments.ToListAsync();
        }
        public async Task<Assignment> GetAssignmentAsync(int assignmentId)
        {
            return await _context.Assignments.FirstOrDefaultAsync(assignment => assignment.AssignmentID == assignmentId);
        }
        public async Task<Assignment> AddAssignment(Assignment assignment)
        {
            _context.Add(assignment);
            _context.SaveChanges();
            return await _context.Assignments.FirstOrDefaultAsync(tempAssignment => tempAssignment.Equals(assignment));
        }
        public async Task<Assignment> EditAssignmentScoreAsync(Assignment assignment)
        {
            var Assignment = await _context.Assignments.FirstOrDefaultAsync(x => x.AssignmentID == assignment.AssignmentID);
            Assignment = assignment;
            _context.Update(Assignment);
            _context.SaveChanges();
            return await _context.Assignments.FirstOrDefaultAsync(x => x == assignment);
        }
        public async Task<Boolean> DeleteAssignment(int assignmentId)
        {
            try 
            {
                var assignment = await _context.Assignments.FirstOrDefaultAsync(assignment => assignment.AssignmentID == assignmentId);
                _context.Remove(assignment);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
            
        }
        
        //Class crud
        public async Task<List<Class>> GetClasssAsync()
        {
            return await _context.Classes.ToListAsync();
        }
        public async Task<Class> GetClassAsync(int ClassId)
        {
            return await _context.Classes.FirstOrDefaultAsync(Class => Class.ClassID == ClassId);
        }
        public async Task<Class> AddClass(Class Class)
        {
            _context.Add(Class);
            _context.SaveChanges();
            return await _context.Classes.FirstOrDefaultAsync(tempClass => tempClass.Equals(Class));
        }
        public async Task<Class> EditClassScoreAsync(Class Class)
        {
            var target = await _context.Classes.FindAsync(Class.ClassID);
            target = Class;
            _context.Update(target);
            _context.SaveChanges();
            return await _context.Classes.FirstOrDefaultAsync(tempClass => tempClass.Equals(Class));
        }
        public async Task<Boolean> DeleteClass(int ClassId)
        {
            try
            {
                var Class = await _context.Classes.FirstOrDefaultAsync(Class => Class.ClassID == ClassId);
                _context.Remove(Class);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        //course crud
        public async Task<List<Course>> GetCoursesAsync()
        {
            return await _context.Courses.ToListAsync();
        }
        public async Task<Course> GetCourseAsync(int courseId)
        {
            return await _context.Courses.FirstOrDefaultAsync(course => course.CourseID == courseId);
        }
        public async Task<Course> AddCourse(Course course)
        {
            _context.Add(course);
            _context.SaveChanges();
            return await _context.Courses.FirstOrDefaultAsync(tempCourse => tempCourse.Equals(course));
        }
        public async Task<Course> EditCourseScoreAsync(Course course)
        {
            var target = await _context.Courses.FindAsync(course.CourseID);
            target = course;
            _context.Update(target);
            _context.SaveChanges();
            return await _context.Courses.FirstOrDefaultAsync(tempCourse => tempCourse.Equals(course));
        }
        public async Task<Boolean> DeleteCourse(int CourseId)
        {
            try
            {
                var Course = await _context.Courses.FirstOrDefaultAsync(course => course.CourseID == CourseId);
                _context.Remove(Course);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        //Enrollment crud
        public async Task<List<Enrollment>> GetEnrollmentsAsync()
        {
            return await _context.Enrollments.ToListAsync();
        }
        public async Task<Enrollment> GetEnrollmentAsync(int EnrollmentId)
        {
            return await _context.Enrollments.FirstOrDefaultAsync(Enrollment => Enrollment.EnrollmentID == EnrollmentId);
        }
        public async Task<Enrollment> AddEnrollment(Enrollment Enrollment)
        {
            _context.Add(Enrollment);
            _context.SaveChanges();
            return await _context.Enrollments.FirstOrDefaultAsync(tempEnrollment => tempEnrollment.Equals(Enrollment));
        }
        public async Task<Enrollment> EditEnrollmentScoreAsync(Enrollment Enrollment)
        {
            var target = await _context.Enrollments.FindAsync(Enrollment.EnrollmentID);
            target = Enrollment;
            _context.Update(target);
            _context.SaveChanges();
            return await _context.Enrollments.FirstOrDefaultAsync(tempEnrollment => tempEnrollment.Equals(Enrollment));
        }
        public async Task<Boolean> DeleteEnrollment(int EnrollmentId)
        {
            try
            {
                var Enrollment = await _context.Enrollments.FirstOrDefaultAsync(Enrollment => Enrollment.EnrollmentID == EnrollmentId);
                _context.Remove(Enrollment);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        //Student crud
        public async Task<List<Student>> GetStudentsAsync()
        {
            return await _context.Students.ToListAsync();
        }
        public async Task<Student> GetStudentAsync(int StudentId)
        {
            return await _context.Students.FirstOrDefaultAsync(Student => Student.StudentId == StudentId);
        }
        public async Task<Student> AddStudent(Student Student)
        {
            _context.Add(Student);
            _context.SaveChanges();
            return await _context.Students.FirstOrDefaultAsync(tempStudent => tempStudent.Equals(Student));
        }
        public async Task<Student> EditStudentScoreAsync(Student Student)
        {
            var target = await _context.Students.FindAsync(Student.StudentId);
            target = Student;
            _context.Update(target);
            _context.SaveChanges();
            return await _context.Students.FirstOrDefaultAsync(tempStudent => tempStudent.Equals(Student));
        }
        public async Task<Boolean> DeleteStudent(int StudentId)
        {
            try
            {
                var Student = await _context.Students.FirstOrDefaultAsync(Student => Student.StudentId == StudentId);
                _context.Remove(Student);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        //teacher crud
        public async Task<List<Teacher>> GetTeachersAsync()
        {
            return await _context.Teachers.ToListAsync();
        }
        public async Task<Teacher> GetTeacherAsync(int TeacherId)
        {
            return await _context.Teachers.FirstOrDefaultAsync(Teacher => Teacher.TeacherID == TeacherId);
        }
        public async Task<Teacher> AddTeacher(Teacher Teacher)
        {
            _context.Add(Teacher);
            _context.SaveChanges();
            return await _context.Teachers.FirstOrDefaultAsync(tempTeacher => tempTeacher.Equals(Teacher));
        }
        public async Task<Teacher> EditTeacherScoreAsync(Teacher Teacher)
        {
            var target = await _context.Teachers.FindAsync(Teacher.TeacherID);
            target = Teacher;
            _context.Update(target);
            _context.SaveChanges();
            return await _context.Teachers.FirstOrDefaultAsync(tempTeacher => tempTeacher.Equals(Teacher));
        }
        public async Task<Boolean> DeleteTeacher(int TeacherId)
        {
            try
            {
                var Teacher = await _context.Teachers.FirstOrDefaultAsync(Teacher => Teacher.TeacherID == TeacherId);
                _context.Remove(Teacher);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        //user crud
        public async Task<List<User>> GetUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }
        public async Task<User> GetUserAsync(int assignmentId)
        {
            return await _context.Users.FirstOrDefaultAsync(User => User.UserId == assignmentId);
        }
        public async Task<User> AddUser(User User)
        {
            _context.Add(User);
            _context.SaveChanges();
            return await _context.Users.FirstOrDefaultAsync(tempUser => tempUser.Equals(User));
        }
        public async Task<User> EditUserScoreAsync(User user)
        {
            var User = await _context.Users.FirstOrDefaultAsync(x => x.UserId == user.UserId);
            User = user;
            _context.Update(User);
            _context.SaveChanges();
            return await _context.Users.FirstOrDefaultAsync(x => x == user);
        }
        public async Task<Boolean> DeleteUser(int assignmentId)
        {
            try
            {
                var User = await _context.Assignments.FirstOrDefaultAsync(User => User.AssignmentID == assignmentId);
                _context.Remove(User);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }
    }
}

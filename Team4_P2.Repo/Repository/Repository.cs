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
            _context.Admins.Update(admin);
            _context.SaveChanges();
            return await _context.Admins.FirstOrDefaultAsync(x => x == admin);
        }
        public Boolean DeleteAdmin(Admin admin)
        {
            try
            {
                _context.Admins.Remove(admin);
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
            return await _context.Assignments.FirstOrDefaultAsync(assignment => assignment.AssignmentId == assignmentId);
        }
        public async Task<Assignment> AddAssignment(Assignment assignment)
        {
            _context.Add(assignment);
            _context.SaveChanges();
            return await _context.Assignments.FirstOrDefaultAsync(tempAssignment => tempAssignment.Equals(assignment));
        }
        public async Task<Assignment> EditAssignmentScoreAsync(Assignment assignment)
        {
            _context.Assignments.Update(assignment);
            _context.SaveChanges();
            return await _context.Assignments.FirstOrDefaultAsync(x => x == assignment);
        }
        public async Task<Boolean> DeleteAssignment(int assignmentId)
        {
            try 
            {
                var assignment = await _context.Assignments.FirstOrDefaultAsync(assignment => assignment.AssignmentId == assignmentId);
                _context.Assignments.Remove(assignment);
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
            return await _context.Classes.FirstOrDefaultAsync(Class => Class.ClassId == ClassId);
        }
        public async Task<Class> AddClass(Class Class)
        {
            _context.Add(Class);
            _context.SaveChanges();
            return await _context.Classes.FirstOrDefaultAsync(tempClass => tempClass.Equals(Class));
        }
        public async Task<Class> EditClassScoreAsync(Class Class)
        {
            _context.Classes.Update(Class);
            _context.SaveChanges();
            return await _context.Classes.FirstOrDefaultAsync(tempClass => tempClass.Equals(Class));
        }
        public async Task<Boolean> DeleteClass(int ClassId)
        {
            try
            {
                var Class = await _context.Classes.FirstOrDefaultAsync(Class => Class.ClassId == ClassId);
                _context.Classes.Remove(Class);
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
            return await _context.Courses.FirstOrDefaultAsync(Course => Course.CourseId == courseId);
        }
        public async Task<Course> AddCourse(Course course)
        {
            _context.Add(course);
            _context.SaveChanges();
            return await _context.Courses.FirstOrDefaultAsync(tempCourse => tempCourse.Equals(course));
        }
        public async Task<Course> EditCourseScoreAsync(Course course)
        {
            _context.Courses.Update(course);
            _context.SaveChanges();
            return await _context.Courses.FirstOrDefaultAsync(tempCourse => tempCourse.Equals(course));
        }
        public async Task<Boolean> DeleteCourse(int CourseId)
        {
            try
            {
                var Course = await _context.Courses.FirstOrDefaultAsync(Course => Course.CourseId == CourseId);
                _context.Courses.Remove(Course);
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
            return await _context.Enrollments.FirstOrDefaultAsync(Enrollment => Enrollment.EnrollmentId == EnrollmentId);
        }
        public async Task<Enrollment> AddEnrollment(Enrollment Enrollment)
        {
            _context.Add(Enrollment);
            _context.SaveChanges();
            return await _context.Enrollments.FirstOrDefaultAsync(tempEnrollment => tempEnrollment.Equals(Enrollment));
        }
        public async Task<Enrollment> EditEnrollmentScoreAsync(Enrollment enrollment)
        {
            _context.Enrollments.Update(enrollment);
            _context.SaveChanges();
            return await _context.Enrollments.FirstOrDefaultAsync(tempEnrollment => tempEnrollment.Equals(enrollment));
        }
        public async Task<Boolean> DeleteEnrollment(int EnrollmentId)
        {
            try
            {
                var Enrollment = await _context.Enrollments.FirstOrDefaultAsync(Enrollment => Enrollment.EnrollmentId == EnrollmentId);
                _context.Enrollments.Remove(Enrollment);
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
        public async Task<Student> EditStudentScoreAsync(Student student)
        {
            _context.Students.Update(student);
            _context.SaveChanges();
            return await _context.Students.FirstOrDefaultAsync(tempStudent => tempStudent.Equals(student));
        }
        public async Task<Boolean> DeleteStudent(int StudentId)
        {
            try
            {
                var Student = await _context.Students.FirstOrDefaultAsync(Student => Student.StudentId == StudentId);
                _context.Students.Remove(Student);
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
            return await _context.Teachers.FirstOrDefaultAsync(Teacher => Teacher.TeacherId == TeacherId);
        }
        public async Task<Teacher> AddTeacher(Teacher Teacher)
        {
            _context.Add(Teacher);
            _context.SaveChanges();
            return await _context.Teachers.FirstOrDefaultAsync(tempTeacher => tempTeacher.Equals(Teacher));
        }
        public async Task<Teacher> EditTeacherScoreAsync(Teacher teacher)
        {
            _context.Teachers.Update(teacher);
            _context.SaveChanges();
            return await _context.Teachers.FirstOrDefaultAsync(tempTeacher => tempTeacher.Equals(teacher));
        }
        public async Task<Boolean> DeleteTeacher(int TeacherId)
        {
            try
            {
                var Teacher = await _context.Teachers.FirstOrDefaultAsync(Teacher => Teacher.TeacherId == TeacherId);
                _context.Teachers.Remove(Teacher);
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
        public async Task<User> AddUser(User user)
        {
            var newUser = new User();
            if(user.Role == Role.Admin)
            {
                newUser.Role = Role.Admin;
            }
            else if(user.Role == Role.Teacher)
            {
                newUser.Role = Role.Teacher;
            }
            else
            {
                newUser.Role = Role.Student;
            }
            _context.Add(newUser);
            _context.SaveChanges();
            return await _context.Users.FirstOrDefaultAsync(tempUser => tempUser.Equals(newUser));
        }
        public async Task<User> Login(User user)
        {
            var login = new User();
            if(user.Role == Role.Admin)
            {
                login = await _context.Users.FirstOrDefaultAsync(u => u.UserName == user.UserName && u.Password == user.Password);
            }
            else if(user.Role == Role.Teacher)
            {
                login = await _context.Users.FirstOrDefaultAsync(u => u.UserName == user.UserName && u.Password == user.Password);
            }
            else
            {
                login = await _context.Users.FirstOrDefaultAsync(u => u.UserName == user.UserName && u.Password == user.Password);
            }
            
            return login;
        }
        public async Task<User> EditUserScoreAsync(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
            return await _context.Users.FirstOrDefaultAsync(x => x == user);
        }
        public async Task<Boolean> DeleteUser(int UserId)
        {
            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(x => x.UserId == UserId);
                _context.Users.Remove(user);
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

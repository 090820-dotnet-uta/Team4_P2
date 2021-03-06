using dummyapi;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Team4_P2.Models;
using Team4_P2.Models.Models;
using Team4_P2.Repo.Data;
using Team4_P2.Repo.Repository;
using Xunit;

namespace Team4_P2.Test
{
    public class AllTests
    {
        [Fact]
        public async void AdminControllerTest()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "yeet").Options;
            using (var context = new AppDbContext(options))
            {
                Repository repo = new Repository(context);
                var _adminController = new AdminController(repo);
                Admin tempAdminOne = new Admin();
                tempAdminOne.AdminId = 1;
                Admin tempAdminTwo = new Admin();
                tempAdminOne.AdminId = 2;
                await _adminController.CreateAdminAsync(tempAdminOne);
                await _adminController.CreateAdminAsync(tempAdminTwo);
                
                ActionResult<List<Admin>> testList = _adminController.GetAll().Result;
                testList = testList.Value;
                Assert.NotNull(testList);
                ActionResult<Admin> testList2 = _adminController.Get(1).Result;
                Assert.NotNull(testList2);

            }
        }
        [Fact]
        public async void CourseControllerTest()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "yeet").Options;
            using (var context = new AppDbContext(options))
            {
                Repository repo = new Repository(context);
                var _CourseController = new CourseController(repo);
                Course tempCourseOne = new Course();
                tempCourseOne.Title = "first";
                
                Course tempCourseTwo = new Course();
                tempCourseOne.Title = "second";
                await _CourseController.CreateCourseAsync(tempCourseOne);
                await _CourseController.CreateCourseAsync(tempCourseTwo);

                ActionResult<List<Course>> testList = _CourseController.GetAll().Result;
                testList = testList.Value;
                Assert.NotNull(testList);
                ActionResult<Course> testList2 = _CourseController.Get(1).Result;
                Assert.NotNull(testList2);
                tempCourseOne.Title = "third";
                await repo.EditCourseScoreAsync(tempCourseOne);
                Assert.Equal("third", (repo.GetCourseAsync(1).Result.Title));
            }
        }
        [Fact]
        public async void UserControllerTest()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "yeetus").Options;
            using (var context = new AppDbContext(options))
            {
                Repository repo = new Repository(context);
                var _UserController = new UserController(repo);
                User tempUserOne = new User();
                tempUserOne.Role = Role.Student;
                tempUserOne.UserName = "a";
                tempUserOne.Password = "b";
                tempUserOne.FirstName = "c";
                tempUserOne.LastName = "d";
                tempUserOne.Gender = 'M';
                await _UserController.CreateUserAsync(tempUserOne);

                ActionResult<List<User>> testList = _UserController.GetAll().Result;
                testList = testList.Value;
                Assert.NotNull(testList);
                ActionResult<User> testList2 = _UserController.Get(1).Result;
                Assert.NotNull(testList2);
                tempUserOne.FirstName = "idk";
                await repo.EditUserScoreAsync(tempUserOne);
                Assert.Equal("idk", (repo.GetUserAsync(1).Result.FirstName));
            }
        }
        [Fact]
        public async void AssignmentControllerTest()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "yeetus2").Options;
            using (var context = new AppDbContext(options))
            {
                Repository repo = new Repository(context);
                var _AssignmentController = new AssignmentController(repo);
                Assignment tempAssignmentOne = new Assignment();
                tempAssignmentOne.AssignmentId = 1;
                tempAssignmentOne.EnrollmentId = 1;
                tempAssignmentOne.Grade = 80;
                tempAssignmentOne.Title = "test";

                await _AssignmentController.CreateAssignmentAsync(tempAssignmentOne);

                ActionResult<List<Assignment>> testList = _AssignmentController.GetAll().Result;
                testList = testList.Value;
                Assert.NotNull(testList);
                ActionResult<Assignment> testList2 = _AssignmentController.Get(1).Result;
                Assert.NotNull(testList2);
                tempAssignmentOne.Title = "idk";
                await repo.EditAssignmentScoreAsync(tempAssignmentOne);
                Assert.Equal(80, tempAssignmentOne.Grade);
                Assert.Equal("idk", (repo.GetAssignmentAsync(1).Result.Title));
            }
        }
        [Fact]
        public async void AddAdminToDb()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "yeet").Options;
            using (var context = new AppDbContext(options))
            {
                Repository repo = new Repository(context);
                Admin Admin = new Admin();

                Admin = await repo.AddAdmin(Admin);

                Assert.True(context.Admins.Contains(Admin));
            }
        }
        //[Fact]
        //public async void putCourseToDb()
        //{
        //    var options = new DbContextOptionsBuilder<AppDbContext>()
        //        .UseInMemoryDatabase(databaseName: "yeet").Options;
        //    using (var context = new AppDbContext(options))
        //    {
        //        Repository repo = new Repository(context);
        //        Course course= new Course();
        //        course.Title = "first";
        //        await repo.AddCourse(course);
        //        course.Title = "second";
        //        await repo.EditCourseScoreAsync(course);
        //        Assert.Equal("second",(repo.GetCourseAsync(1).Result.Title));
        //    }
        //}
        [Fact]
        public async void DeleteAdminToDb()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "yeet").Options;
            using (var context = new AppDbContext(options))
            {
                Repository repo = new Repository(context);
                Admin Admin = new Admin();

                Admin = await repo.AddAdmin(Admin);

                bool rip = repo.DeleteAdmin(Admin);
                Assert.False(context.Admins.Contains(Admin));
            }
        }
        [Fact]
        public async void AddAssignmentToDb()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "yeet").Options;
            using (var context = new AppDbContext(options))
            {
                Repository repo = new Repository(context);
                Assignment assignment = new Assignment();
                assignment.Title = "Ok boomer";
                assignment.EnrollmentId = 1;

                assignment = await repo.AddAssignment(assignment);

                Assert.True(context.Assignments.Contains(assignment));
            }
        }
        [Fact]
        public async void DeleteAssignmentToDb()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "yeet").Options;
            using (var context = new AppDbContext(options))
            {
                Repository repo = new Repository(context);
                Assignment Assignment = new Assignment();
                Assignment.Title = "Ok boomer";
                Assignment.EnrollmentId = 1;

                Assignment = await repo.AddAssignment(Assignment);

                bool rip = await repo.DeleteAssignment(Assignment.AssignmentId);
                Assert.False(context.Assignments.Contains(Assignment));
            }
        }
        [Fact]
        public async void AddClassToDb()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "yeet").Options;
            using (var context = new AppDbContext(options))
            {
                Repository repo = new Repository(context);
                Class Class = new Class();

                Class = await repo.AddClass(Class);

                Assert.True(context.Classes.Contains(Class));
            }
        }
        [Fact]
        public async void DeleteClassToDb()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "yeet").Options;
            using (var context = new AppDbContext(options))
            {
                Repository repo = new Repository(context);
                Class Class = new Class();

                Class = await repo.AddClass(Class);

                bool rip = await repo.DeleteClass(Class.ClassId);
                Assert.False(context.Classes.Contains(Class));
            }
        }
        [Fact]
        public async void AddCourseToDb()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "yeet2").Options;
            using (var context = new AppDbContext(options))
            {
                Repository repo = new Repository(context);
                Course course = new Course();
                course.Title = "Ok boomer";

                course = await repo.AddCourse(course);

                Assert.True(context.Courses.Contains(course));
            }
        }
        [Fact]
        public async void DeleteCourseToDb()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "yeet2").Options;
            using (var context = new AppDbContext(options))
            {
                Repository repo = new Repository(context);
                Course course = new Course();
                course.Title = "Ok boomer";

                course = await repo.AddCourse(course);

                bool rip = await repo.DeleteCourse(course.CourseId);
                Assert.False(context.Courses.Contains(course));
            }
        }
        [Fact]
        public async void AddEnrollmentToDb()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "yeet").Options;
            using (var context = new AppDbContext(options))
            {
                Repository repo = new Repository(context);
                Enrollment Enrollment = new Enrollment();

                Enrollment = await repo.AddEnrollment(Enrollment);

                Assert.True(context.Enrollments.Contains(Enrollment));
            }
        }
        [Fact]
        public async void DeleteEnrollmentToDb()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "yeet").Options;
            using (var context = new AppDbContext(options))
            {
                Repository repo = new Repository(context);
                Enrollment Enrollment = new Enrollment();

                Enrollment = await repo.AddEnrollment(Enrollment);

                bool rip = await repo.DeleteEnrollment(Enrollment.EnrollmentId);
                Assert.False(context.Enrollments.Contains(Enrollment));
            }
        }
        [Fact]
        public async void AddStudentToDb()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "yeet").Options;
            using (var context = new AppDbContext(options))
            {
                Repository repo = new Repository(context);
                Student Student = new Student();

                Student = await repo.AddStudent(Student);

                Assert.True(context.Students.Contains(Student));
            }
        }
        [Fact]
        public async void DeleteStudentToDb()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "yeet").Options;
            using (var context = new AppDbContext(options))
            {
                Repository repo = new Repository(context);
                Student Student = new Student();

                Student = await repo.AddStudent(Student);

                bool rip = await repo.DeleteStudent(Student.StudentId);
                Assert.False(context.Students.Contains(Student));
            }
        }
        [Fact]
        public async void AddTeacherToDb()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "yeet").Options;
            using (var context = new AppDbContext(options))
            {
                Repository repo = new Repository(context);
                Teacher Teacher = new Teacher();

                Teacher = await repo.AddTeacher(Teacher);

                Assert.True(context.Teachers.Contains(Teacher));
            }
        }
        [Fact]
        public async void DeleteTeacherToDb()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "yeet").Options;
            using (var context = new AppDbContext(options))
            {
                Repository repo = new Repository(context);
                Teacher Teacher = new Teacher();

                Teacher = await repo.AddTeacher(Teacher);

                bool rip = await repo.DeleteTeacher(Teacher.TeacherId);
                Assert.False(context.Teachers.Contains(Teacher));
            }
        }
        [Fact]
        public async void AddUserToDb()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "yeet").Options;
            using (var context = new AppDbContext(options))
            {
                Repository repo = new Repository(context);
                User User = new User();

                User = await repo.AddUser(User);

                Assert.True(context.Users.Contains(User));
            }
        }
        [Fact]
        public async void DeleteUserToDb()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "yeet").Options;
            using (var context = new AppDbContext(options))
            {
                Repository repo = new Repository(context);
                User User = new User();

                User = await repo.AddUser(User);

                bool rip = await repo.DeleteUser(User.UserId);
                Assert.False(context.Users.Contains(User));
            }
        }
        [Fact]
        public async void makeModels()
        {
            Assignment assignment = new Assignment();
            assignment.AssignmentId = 1;
            assignment.EnrollmentId = 1;
            assignment.Grade = 70;
            assignment.Title = "test";
            Assert.Equal(70, assignment.Grade);
        }
    }
}

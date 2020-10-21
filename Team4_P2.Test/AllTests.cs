using Microsoft.EntityFrameworkCore;
using System;
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

                bool rip = await repo.DeleteAdmin(Admin.AdminId);
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
                .UseInMemoryDatabase(databaseName: "yeet").Options;
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
                .UseInMemoryDatabase(databaseName: "yeet").Options;
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
    }
}

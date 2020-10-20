using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Team4_P2.Models;
using Team4_P2.Repo.Data;
using Team4_P2.Repo.Repository;
using Xunit;

namespace Team4_P2.Test
{
    public class AllTests
    {
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
                assignment.EnrollmentID = 1;

                assignment = await repo.AddAssignment(assignment);

                Assert.True(context.Assignments.Contains(assignment));
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

                bool rip = await repo.DeleteCourse(course.CourseID);
                Assert.False(context.Courses.Contains(course));
            }
        }
    }
}

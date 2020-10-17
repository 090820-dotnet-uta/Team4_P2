using System;
using System.Collections.Generic;
using System.Text;
using Team4_P2.Repo.Data;
using System.Linq;
using System.Threading.Tasks;
using Team4_P2.Models;
using Microsoft.EntityFrameworkCore;

namespace Team4_P2.Repo.Repository
{
    public class Repository
    {
        private readonly AppDbContext _context;
        public Repository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Assignment>> GetAssignmentsAsync()
        {
            return await _context.Assignments.ToListAsync();
        }
        public async Task<Assignment> GetAssignmentAsync(int assignmentId)
        {
            return await _context.Assignments.FirstOrDefaultAsync(assignment => assignment.AssignmentID == assignmentId);
        }
        public async Task<Assignment> EditAssignmentScoreAsync(int assignmentId, int enrollmentId, int grade, string title)
        {
            var assignment = await _context.Assignments.FirstOrDefaultAsync(x => x.AssignmentID == assignmentId);
            assignment.EnrollmentID = enrollmentId;
            assignment.Grade = grade;
            assignment.Title = title;
            _context.Update(assignment);
            _context.SaveChanges();
            return await _context.Assignments.FirstOrDefaultAsync(x => x == assignment);
        }
        public Boolean DeleteAssignment(int assignmentId)
        {
            try 
            {
                var assignment = _context.Assignments.FirstOrDefaultAsync(assignment => assignment.AssignmentID == assignmentId);
                _context.Remove(assignment);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
            
        }

        public async Task<List<Course>> GetCoursesAsync()
        {
            return await _context.Courses.ToListAsync();
        }
        public async Task<Course> GetCourseAsync(int courseId)
        {
            return await _context.Courses.FirstOrDefaultAsync(course => course.CourseID == courseId);
        }
        public async Task<Course> EditCourseScoreAsync(int CourseId, string title)
        {
            var Course = await _context.Courses.FirstOrDefaultAsync(x => x.CourseID == CourseId);
            Course.Title = title;
            _context.Update(Course);
            _context.SaveChanges();
            return await _context.Courses.FirstOrDefaultAsync(x => x == Course);
        }
        public Boolean DeleteCourse(int CourseId)
        {
            try
            {
                var Course = _context.Courses.FirstOrDefaultAsync(Course => Course.CourseID == CourseId);
                _context.Remove(Course);
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

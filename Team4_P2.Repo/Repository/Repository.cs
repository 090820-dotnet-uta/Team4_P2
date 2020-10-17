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
            return await _context.Assignments.FirstOrDefaultAsync(assignment => assignment.AssignmentId == assignmentId);
        }


        public async Task<List<Course>> GetCoursesAsync()
        {
            return await _context.Courses.ToListAsync();
        }
        public async Task<Course> GetCourseAsync(int courseId)
        {
            return await _context.Courses.FirstOrDefaultAsync(course => course.CourseID == courseId);
        }
    }
}

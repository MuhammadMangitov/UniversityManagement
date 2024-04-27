using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using lesson_03.Data;
using lesson_03.Entities;

namespace lesson_03.Controllers
{
    public class CourseAssigmentsController : Controller
    {
        private readonly UniverstiyDbContext _context;

        public CourseAssigmentsController(UniverstiyDbContext context)
        {
            _context = context;
        }

        // GET: CourseAssigments
        public async Task<IActionResult> Index(string? searchString)
        {
            var query = _context.CourseAssigments
                .Include(c => c.Course)
                .Include(c => c.Instructor)
                .AsQueryable();
            if (!String.IsNullOrWhiteSpace(searchString))
            {
                query = query.Where(x => x.Room!.Contains(searchString));
            }

            var assigments = await query.ToListAsync();
            ViewBag.Search = searchString;

            return View(assigments);
        }

        // GET: CourseAssigments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseAssigment = await _context.CourseAssigments
                .Include(c => c.Course)
                .Include(c => c.Instructor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (courseAssigment == null)
            {
                return NotFound();
            }

            return View(courseAssigment);
        }

        // GET: CourseAssigments/Create
        public IActionResult Create()
        {
            ViewData["CoureseId"] = new SelectList(_context.Courses, "Id", "Name");
            ViewData["InstructorId"] = new SelectList(_context.Instructors, "Id", "FirstName");
            return View();
        }

        // POST: CourseAssigments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Room,CoureseId,InstructorId")] CourseAssigment courseAssigment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(courseAssigment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CoureseId"] = new SelectList(_context.Courses, "Id", "Name", courseAssigment.CourseId);
            ViewData["InstructorId"] = new SelectList(_context.Instructors, "Id", "FirstName", courseAssigment.InstructorId);
            return View(courseAssigment);
        }

        // GET: CourseAssigments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseAssigment = await _context.CourseAssigments.FindAsync(id);
            if (courseAssigment == null)
            {
                return NotFound();
            }
            ViewData["CoureseId"] = new SelectList(_context.Courses, "Id", "Name", courseAssigment.CourseId);
            ViewData["InstructorId"] = new SelectList(_context.Instructors, "Id", "FirstName", courseAssigment.InstructorId);
            return View(courseAssigment);
        }

        // POST: CourseAssigments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Room,CoureseId,InstructorId")] CourseAssigment courseAssigment)
        {
            if (id != courseAssigment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(courseAssigment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourseAssigmentExists(courseAssigment.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CoureseId"] = new SelectList(_context.Courses, "Id", "Name", courseAssigment.CourseId);
            ViewData["InstructorId"] = new SelectList(_context.Instructors, "Id", "FirstName", courseAssigment.InstructorId);
            return View(courseAssigment);
        }

        // GET: CourseAssigments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseAssigment = await _context.CourseAssigments
                .Include(c => c.Course)
                .Include(c => c.Instructor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (courseAssigment == null)
            {
                return NotFound();
            }

            return View(courseAssigment);
        }

        // POST: CourseAssigments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var courseAssigment = await _context.CourseAssigments.FindAsync(id);
            if (courseAssigment != null)
            {
                _context.CourseAssigments.Remove(courseAssigment);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CourseAssigmentExists(int id)
        {
            return _context.CourseAssigments.Any(e => e.Id == id);
        }
    }
}

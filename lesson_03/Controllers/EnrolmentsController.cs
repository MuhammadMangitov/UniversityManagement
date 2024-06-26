﻿using System;
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
    public class EnrolmentsController : Controller
    {
        private readonly UniverstiyDbContext _context;

        public EnrolmentsController(UniverstiyDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var universtiyDbContext = _context.Enrolments.Include(e => e.CourseAssigment).Include(e => e.Student);
            return View(await universtiyDbContext.ToListAsync());
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enrolment = await _context.Enrolments
                .Include(e => e.CourseAssigment)
                .Include(e => e.Student)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (enrolment == null)
            {
                return NotFound();
            }

            return View(enrolment);
        }

        // GET: Enrolments/Create
        public IActionResult Create()
        {
            ViewData["CourseAssigmentId"] = new SelectList(_context.CourseAssigments, "Id", "Room");
            ViewData["StudentId"] = new SelectList(_context.Students, "Id", "FirsName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EnrolmentDate,StudentId,CourseAssigmentId")] Enrolment enrolment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(enrolment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseAssigmentId"] = new SelectList(_context.CourseAssigments, "Id", "Room", enrolment.CourseAssigmentId);
            ViewData["StudentId"] = new SelectList(_context.Students, "Id", "FirsName", enrolment.StudentId);
            return View(enrolment);
        }

        // GET: Enrolments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enrolment = await _context.Enrolments.FindAsync(id);
            if (enrolment == null)
            {
                return NotFound();
            }
            ViewData["CourseAssigmentId"] = new SelectList(_context.CourseAssigments, "Id", "Room", enrolment.CourseAssigmentId);
            ViewData["StudentId"] = new SelectList(_context.Students, "Id", "FirsName", enrolment.StudentId);
            return View(enrolment);
        }

        // POST: Enrolments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EnrolmentDate,StudentId,CourseAssigmentId")] Enrolment enrolment)
        {
            if (id != enrolment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(enrolment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnrolmentExists(enrolment.Id))
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
            ViewData["CourseAssigmentId"] = new SelectList(_context.CourseAssigments, "Id", "Room", enrolment.CourseAssigmentId);
            ViewData["StudentId"] = new SelectList(_context.Students, "Id", "FirsName", enrolment.StudentId);
            return View(enrolment);
        }

        // GET: Enrolments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enrolment = await _context.Enrolments
                .Include(e => e.CourseAssigment)
                .Include(e => e.Student)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (enrolment == null)
            {
                return NotFound();
            }

            return View(enrolment);
        }

        // POST: Enrolments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var enrolment = await _context.Enrolments.FindAsync(id);
            if (enrolment != null)
            {
                _context.Enrolments.Remove(enrolment);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EnrolmentExists(int id)
        {
            return _context.Enrolments.Any(e => e.Id == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UniversityOfScienceTwo.Data;
using UniversityOfScienceTwo.Models;

namespace UniversityOfScienceTwo.Pages.Faculty
{
    public class EditModel : PageModel
    {
        private readonly UniversityOfScienceTwo.Data.ApplicationDbContext _context;

        public EditModel(UniversityOfScienceTwo.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Professor Professor { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Professor == null)
            {
                return NotFound();
            }

            var professor =  await _context.Professor.FirstOrDefaultAsync(m => m.ProfessorId == id);
            if (professor == null)
            {
                return NotFound();
            }
            Professor = professor;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Professor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProfessorExists(Professor.ProfessorId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ProfessorExists(int id)
        {
          return (_context.Professor?.Any(e => e.ProfessorId == id)).GetValueOrDefault();
        }
    }
}

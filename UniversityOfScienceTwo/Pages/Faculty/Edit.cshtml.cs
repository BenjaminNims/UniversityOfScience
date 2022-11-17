using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UniversityOfScienceTwo.Authorization;
using UniversityOfScienceTwo.Data;
using UniversityOfScienceTwo.Models;

namespace UniversityOfScienceTwo.Pages.Faculty
{
    public class EditModel : DI_BasePageModelProf
    {
        public EditModel(
        ApplicationDbContext context,
        IAuthorizationService authorizationService,
        UserManager<IdentityUser> userManager)
        : base(context, authorizationService, userManager)
        {
        }

        [BindProperty]
        public Professor Professor { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Professor? professor = await Context.Professor.FirstOrDefaultAsync(m => m.ProfessorId == id);

            if (professor == null)
            {
                return NotFound();
            }

            Professor = professor;

            var isAuthorized = await AuthorizationService.AuthorizeAsync(User, Professor, UniversityOperations.Update);

            if (!isAuthorized.Succeeded)
            {
                return Forbid();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var professor = await Context.Professor.AsNoTracking().FirstOrDefaultAsync(m => m.ProfessorId == id);

            if (professor == null)
            {
                return NotFound();
            }

            Professor.OwnerId = professor.OwnerId;

            Context.Attach(Professor).State = EntityState.Modified;

            try
            {
                await Context.SaveChangesAsync();
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
          return (Context.Professor?.Any(e => e.ProfessorId == id)).GetValueOrDefault();
        }
    }
}

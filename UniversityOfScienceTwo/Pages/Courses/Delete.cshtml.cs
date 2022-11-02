using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using UniversityOfScienceTwo.Data;
using UniversityOfScienceTwo.Models;
using UniversityOfScienceTwo.Authorization;

namespace UniversityOfScienceTwo.Pages.Courses
{
    public class DeleteModel : DI_BasePageModel
    {

      public DeleteModel(
      ApplicationDbContext context,
      IAuthorizationService authorizationService,
      UserManager<IdentityUser> userManager)
      : base(context, authorizationService, userManager)
      {
      }

        [BindProperty]
        public Course Course { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {

            Course? _course = await Context.Course.FirstOrDefaultAsync(
                                             m => m.ID == id);

            if (_course == null)
            {
                return NotFound();
            }

            Course = _course;

            var isAuthorized = await AuthorizationService.AuthorizeAsync(
                                                 User, Course,
                                                 UniversityOperations.Delete);

            if (!isAuthorized.Succeeded)
            {
                return Forbid();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            var course = await Context.Course.AsNoTracking().FirstOrDefaultAsync(m => m.ID == id);
            

            if (course != null)
            {
                return NotFound();
            }

            var isAuthorized = await AuthorizationService.AuthorizeAsync(
                                                 User, Course,
                                                 UniversityOperations.Delete);

            if (!isAuthorized.Succeeded)
            {
                return Forbid();
            }

            Context.Course.Remove(course);
            await Context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using UniversityOfScienceTwo.Data;
using UniversityOfScienceTwo.Models;
using UniversityOfScienceTwo.Authorization;

namespace UniversityOfScienceTwo.Pages.Courses
{
    public class CreateModel : DI_BasePageModel
    {

        public CreateModel(
            ApplicationDbContext context,
            IAuthorizationService authorizationService,
            UserManager<IdentityUser> userManager)
            : base(context, authorizationService, userManager)
        {
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Course Course { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            Course.OwnerID = UserManager.GetUserId(User);

            var isAuthorized = await AuthorizationService.AuthorizeAsync(User, Course, UniversityOperations.Create);

            if (!isAuthorized.Succeeded)
            {
                return Forbid();
            }

            Context.Course.Add(Course);

            await Context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

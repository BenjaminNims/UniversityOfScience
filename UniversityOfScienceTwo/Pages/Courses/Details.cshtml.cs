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
    public class DetailsModel : DI_BasePageModel
    {


        public DetailsModel(
      ApplicationDbContext context,
      IAuthorizationService authorizationService,
      UserManager<IdentityUser> userManager)
      : base(context, authorizationService, userManager)
      {
      }

      public Course Course { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            Course? _course = await Context.Course.FirstOrDefaultAsync(m => m.CourseId == id);
            if (_course == null)
            {
                return NotFound();
            }

            Course = _course;

            var isAuthorized = User.IsInRole(Constants.UniversityProfessorsRole) ||
                           User.IsInRole(Constants.UniversityAdministratorsRole);

            var currentUserId = UserManager.GetUserId(User);

            if (!isAuthorized
            && currentUserId != Course.OwnerId
            && Course.Status != CourseStatus.Approved)
            {
                return Forbid();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id, CourseStatus status)
        {
            var course = await Context.Course.FirstOrDefaultAsync(
                                                      m => m.CourseId == id);

            if (course == null)
            {
                return NotFound();
            }

            var contactOperation = (status == CourseStatus.Approved)
                                                       ? UniversityOperations.Approve
                                                       : UniversityOperations.Reject;

            var isAuthorized = await AuthorizationService.AuthorizeAsync(User, course,
                                        contactOperation);
            if (!isAuthorized.Succeeded)
            {
                return Forbid();
            }
            course.Status = status;
            Context.Course.Update(course);
            await Context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

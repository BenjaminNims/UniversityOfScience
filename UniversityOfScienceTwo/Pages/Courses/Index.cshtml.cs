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
    public class IndexModel : DI_BasePageModel
    {
        public IndexModel(
        ApplicationDbContext context,
        IAuthorizationService authorizationService,
        UserManager<IdentityUser> userManager)
        : base(context, authorizationService, userManager)
        {
        }

        public IList<Course> Course { get;set; } = default!;

        public async Task OnGetAsync()
        {
            var courses = from c in Context.Course
                           select c;

            var isAuthorized = User.IsInRole(Constants.UniversityProfessorsRole) ||
                           User.IsInRole(Constants.UniversityAdministratorsRole);

            var currentUserId = UserManager.GetUserId(User);

            // Only approved courses are shown unless you're authorized to see them
            // or you are the owner.
            if (!isAuthorized)
            {
                courses = courses.Where(c => c.Status == CourseStatus.Approved
                                            || c.OwnerID == currentUserId);
            }

            Course = await courses.ToListAsync();
        }
    }
}

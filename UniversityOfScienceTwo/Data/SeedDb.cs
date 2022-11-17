using UniversityOfScienceTwo.Authorization;
using UniversityOfScienceTwo.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using UniversityOfScienceTwo.Data;


namespace UniversityOfScienceTwo.Data
{
    public static class SeedData
    {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8604 // Dereference of a possibly null reference.
        #region snippet_Initialize
        public static async Task Initialize(IServiceProvider serviceProvider, string testUserPw)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                // For sample purposes seed both with the same password.
                // Password is set with the following:
                // dotnet user-secrets set SeedUserPW <pw>
                // The admin user can do anything

                var adminID = await EnsureUser(serviceProvider, testUserPw, "admin@uscience.com");
                await EnsureRole(serviceProvider, adminID, Constants.UniversityAdministratorsRole);

                // allowed user can create and edit contacts that they create
                var managerID = await EnsureUser(serviceProvider, testUserPw, "norm@uscience.com");
                await EnsureRole(serviceProvider, managerID, Constants.UniversityProfessorsRole);

                SeedDB(context, adminID, managerID);
            }
        }

        private static async Task<string> EnsureUser(IServiceProvider serviceProvider,
                                                    string testUserPw, string UserName)
        {
            var userManager = serviceProvider.GetService<UserManager<IdentityUser>>();

            var user = await userManager.FindByNameAsync(UserName);
            if (user == null)
            {
                user = new IdentityUser
                {
                    UserName = UserName,
                    EmailConfirmed = true
                };
                await userManager.CreateAsync(user, testUserPw);
            }

            _ = user ?? throw new Exception("This password belongs in the doghouse. Try a stronger one.");

            return user.Id;
        }

        private static async Task<IdentityResult> EnsureRole(IServiceProvider serviceProvider,
                                                                      string uid, string role)
        {
            var roleManager = serviceProvider.GetService<RoleManager<IdentityRole>>();

            _ = roleManager ?? throw new Exception("roleManager is null.");

            IdentityResult IR;
            if (!await roleManager.RoleExistsAsync(role))
            {
                IR = await roleManager.CreateAsync(new IdentityRole(role));
            }

            var userManager = serviceProvider.GetService<UserManager<IdentityUser>>();

            //if (userManager == null)
            //{
            //    throw new Exception("userManager is null");
            //}

            var user = await userManager.FindByIdAsync(uid);

            _ = user ?? throw new Exception("The testUserPw password belongs in the doghouse. Try a stronger one.");

            IR = await userManager.AddToRoleAsync(user, role);

            return IR;
        }
        #endregion


        #region snippet1
        public static void SeedDB(ApplicationDbContext context, string adminID, string managerID)
        {

            if (context.Course.Any())
            {
                return;   // DB has been seeded
            }

            context.Course.AttachRange(
            #region snippet_Contact
                new Course
                {
                    Name = "Introduction to Logic",
                    Designation = "LOG102",
                    Status = CourseStatus.Approved,
                    OwnerId = adminID
                },
            #endregion
            #endregion
                new Course
                {
                    Name = "Remedial Chaos Theory",
                    Designation = "COMM102",
                    Status = CourseStatus.Approved,
                    OwnerId = adminID
                }
                );

            if (context.Professor.Any())
            {
                return;   // DB has been seeded
            }

            context.Professor.AttachRange(
                new Professor
                {
                   FirstName = "Norman",
                   LastName = "Macdonald",
                   Email = "norm@uscience.com",
                   OwnerId = managerID,
                },
                new Professor
                {
                   FirstName = "Gregory",
                   LastName = "Ilyenivich",
                   Email = "greg@uscience.com",
                   OwnerId = managerID
                }
                );
            try
            {
                context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException e)
            {
                Console.WriteLine(e.Message);
                throw e;
            }
            
        }
    }
}
#pragma warning restore CS8602 // Dereference of a possibly null reference.
#pragma warning restore CS8604 // Dereference of a possibly null reference.
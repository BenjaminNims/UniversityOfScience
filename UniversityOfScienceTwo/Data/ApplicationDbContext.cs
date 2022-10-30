using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UniversityOfScienceTwo.Models;

namespace UniversityOfScienceTwo.Data;

public class ApplicationDbContext : IdentityDbContext
{

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {

    }

    public DbSet<UniversityOfScienceTwo.Models.Professor>? Professor { get; set; }

    public DbSet<UniversityOfScienceTwo.Models.Student>? Student { get; set; }

}


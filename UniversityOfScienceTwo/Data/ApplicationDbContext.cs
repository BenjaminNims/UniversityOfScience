using System.Data.Entity.ModelConfiguration.Conventions;
using System.Reflection.Metadata;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using EntityFramework.Exceptions.PostgreSQL;
using UniversityOfScienceTwo.Models;
using System.Collections.Generic;
using System.Data.Entity;

namespace UniversityOfScienceTwo.Data;

public class ApplicationDbContext : IdentityDbContext
{

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public Microsoft.EntityFrameworkCore.DbSet<UniversityOfScienceTwo.Models.Course>? Course { get; set; }

    public Microsoft.EntityFrameworkCore.DbSet<UniversityOfScienceTwo.Models.Professor>? Professor { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }

}


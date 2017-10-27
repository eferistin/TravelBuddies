using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using myProject.Models;

namespace myProject.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        //create tables in database
        public DbSet<Planning> Plans { get; set; }
        public DbSet<ApprovedMatch> ApprovedMatches { get; set; }
        public DbSet<Chat> Chats { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using Services.AuthAPI;
using Services.AuthAPI.Model;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;

namespace Services.AuthAPI.Data
{

    //IdentityDbContext is a class provided by ASP.NET Core Identity that represents the database context
    //for managing user authentication and authorization.
    //It provides a set of tables and relationships for storing user information, roles, claims, and other related data.


    /// <summary>
    /// Used Of IdentityDbContext<IdentityUser>
    /// 
    /// Inside .NET: You only write C# classes (IdentityDbContext, IdentityUser), which act as the blueprint describing how user data should look
   /// Inside Your Database: Entity Framework Core uses that blueprint to physically create 7 real tables(like AspNetUsers) directly inside your SQL database.

    ///Data Storage: When someone registers or logs in, their email, username, and hashed password get saved into your actual database tables, not inside.NET.

    /// Bottom Line: .NET holds the C# logic and rules, but your actual database holds the physical tables and user data.
    /// 
    /// 
    /// 
    /// 
    /// 
    /// </summary>
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
         
        }
    }
}

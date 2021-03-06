﻿using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace TaskManagementProj.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public ICollection<TaskModel> Tasks { get; set; }
        public ICollection<Project> Projects { get; set; }
        public ICollection<UrgentNote> UrgentNotes { get; set; }
        public ICollection<Notification> Notifications { get; set; }
        public int DaliySalary { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<TaskModel> Tasks { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<UrgentNote> UrgentNotes { get; set; }
        public DbSet<Notification> Notifications { get; set; }


        public ApplicationDbContext()
            : base("TMDB", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
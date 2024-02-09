using DataLayer.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Context : DbContext
    {

        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

       
        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieCasts> MovieCasts { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>().HasData(new User()
            {
                UserId = 1,
                UserName = "حسام",
                Email = "hesam@yahoo.com",
                IsAdmin = true,
                Password = "123",
                AvatarName = "Default.gpj"
            });



            modelBuilder.Entity<Role>().HasData(new Role()
            {
                RoleId = 1,
                RoleName = "Admin"
            });


            modelBuilder.Entity<Role>().HasData(new Role()
            {
                RoleId = 2,
                RoleName = "User"
            });



            var cascadeFKs = modelBuilder.Model.GetEntityTypes()
                 .SelectMany(t => t.GetForeignKeys())
                 .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKs)
                fk.DeleteBehavior = DeleteBehavior.Restrict;
        }

    }
}


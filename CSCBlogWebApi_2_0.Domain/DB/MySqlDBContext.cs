 using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using CSCBlogWebApi_2_0.Model.TableModel;

namespace CSCBlogWebApi_2_0.Domain.DB
{
    public class MySqlDbContext : DbContext
    {
        public MySqlDbContext(DbContextOptions<MySqlDbContext> options) : base(options)
        {

        }

        public DbSet<User_Info> UserInfo { set; get; }

        public DbSet<Role_Info> RoleInfo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User_Info>().ToTable("User_Info");
            modelBuilder.Entity<Role_Info>().ToTable("Role_Info");
            base.OnModelCreating(modelBuilder);
        }

    }
}

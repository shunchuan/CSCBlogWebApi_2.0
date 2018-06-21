using CSCBlogWebApi_2_0.Model.TableModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CSCBlogWebApi_2_0.Domain
{
    public class DBContext: DbContext
    {
        private readonly string connectstr;
        public DBContext(string connectstr)
        {
            this.connectstr = connectstr;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(connectstr);
            base.OnConfiguring(optionsBuilder);
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

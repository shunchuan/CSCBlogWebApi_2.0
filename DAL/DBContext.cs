using Entity.Table;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class DBContext: DbContext
    {
        public DBContext()
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(Utils.CreateInstance().ReadConnectionStrOfDataBase());
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

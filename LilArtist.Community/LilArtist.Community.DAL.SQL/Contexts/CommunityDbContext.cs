using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LilArtist.Community.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace LilArtist.Community.DAL.SQL
{
    public class CommunityDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=localhost, 1433;database=TestApiDB;User Id=sa;password=jfwQPWjd3dd;trusted_connection=False");
            //optionsBuilder.UseSqlServer("server=DESKTOP-KQKU8P9\\SQLEXPRESS;database=TestApiDB;trusted_connection=True");
        }

        public DbSet<User> users { get; set; }
        public DbSet<Role> roles { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using SimpleCodeTT.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleCodeTT.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<User> Users { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
    }
}

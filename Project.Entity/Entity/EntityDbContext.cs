using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Project.Entity.Models;

namespace Project.Entity.Entity
{
    public class EntityDbContext:DbContext
    {
        public DbSet<ToDoData> ToDoDatas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder
                .UseNpgsql("ConnectionString");
       
    }
}

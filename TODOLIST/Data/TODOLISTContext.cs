using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TODOLIST.Models;

namespace TODOLIST.Data
{
    public class TODOLISTContext : DbContext
    {
        public TODOLISTContext (DbContextOptions<TODOLISTContext> options)
            : base(options)
        {
        }

        public DbSet<TODOLIST.Models.List> List { get; set; } = default!;
        public DbSet<TODOLIST.Models.TodoTask> TodoTask { get; set; } = default!;
    }
}

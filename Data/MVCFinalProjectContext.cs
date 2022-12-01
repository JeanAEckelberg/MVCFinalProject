using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MVCFinalProject.Models;

namespace MVCFinalProject.Data
{
    public class MVCFinalProjectContext : DbContext
    {
        public MVCFinalProjectContext (DbContextOptions<MVCFinalProjectContext> options)
            : base(options)
        {
        }

        public DbSet<MVCFinalProject.Models.Computer> Computer { get; set; } = default!;
    }
}

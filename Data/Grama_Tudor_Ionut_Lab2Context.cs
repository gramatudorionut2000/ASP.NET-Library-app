using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Grama_Tudor_Ionut_Lab2.Models;

namespace Grama_Tudor_Ionut_Lab2.Data
{
    public class Grama_Tudor_Ionut_Lab2Context : DbContext
    {
        public Grama_Tudor_Ionut_Lab2Context (DbContextOptions<Grama_Tudor_Ionut_Lab2Context> options)
            : base(options)
        {
        }

        public DbSet<Grama_Tudor_Ionut_Lab2.Models.Book> Book { get; set; } = default!;

        public DbSet<Grama_Tudor_Ionut_Lab2.Models.Publisher> Publisher { get; set; }

        public DbSet<Grama_Tudor_Ionut_Lab2.Models.Category> Category { get; set; }
    }
}

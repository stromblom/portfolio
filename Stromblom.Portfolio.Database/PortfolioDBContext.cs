using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Stromblom.Portfolio.Database.Models;

namespace Stromblom.Portfolio.Database
{
    public class PortfolioDBContext : DbContext
    {
        public PortfolioDBContext()
            : base("DefaultConnection")
        {
        
        }

        public DbSet<Project> Projects { get; set; }

    }
}

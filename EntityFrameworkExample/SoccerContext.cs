using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkExample
{
    public class SoccerContext : DbContext
    {
        public SoccerContext() : base("DbConnection")
        { }

        public DbSet<Player> Players { get; set; }
       
    }
}

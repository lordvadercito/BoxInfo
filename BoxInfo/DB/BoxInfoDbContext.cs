using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoxInfo.DB
{
    public class BoxInfoDbContext : DbContext
    {
        public BoxInfoDbContext(DbContextOptions<BoxInfoDbContext> options)
            : base(options)
        {

        }
    }
}

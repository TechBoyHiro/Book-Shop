using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Models
{
    public class STDbContext : IdentityDbContext<User>
    {
        public STDbContext(DbContextOptions<STDbContext> options)
        :base(options)
        { }

        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
    }
}

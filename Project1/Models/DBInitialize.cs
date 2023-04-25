using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Models
{
    public static class DBInitialize
    {
        public static STDbContext _context;

        public static void Initialize(IServiceProvider serviceProvider)
        {
            _context = new STDbContext(serviceProvider.GetRequiredService<DbContextOptions<STDbContext>>());
        }
    }
}

using LuminiHire.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LuminiHire.Contexts
{
    public class SQLiteDBContext : IdentityDbContext<User>
    {
        public SQLiteDBContext(DbContextOptions<SQLiteDBContext> options)
      : base(options)
        { }

        public DbSet<User> User { get; set; }
    }
}

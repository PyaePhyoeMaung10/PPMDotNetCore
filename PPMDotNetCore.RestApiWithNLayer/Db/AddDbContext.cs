﻿using Microsoft.EntityFrameworkCore;
using PPMDotNetCore.RestApiWithNLayer.Models;

namespace PPMDotNetCore.RestApiWithNLayer.Db
{
    public class AddDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString.SqlConnectionStringBuilder.ConnectionString);
        }
        public DbSet<BlogsModel> Blogs { get; set; }
    }
}

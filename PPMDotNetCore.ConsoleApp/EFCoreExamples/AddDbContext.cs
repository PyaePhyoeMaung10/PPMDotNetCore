﻿using Microsoft.EntityFrameworkCore;
using PPMDotNetCore.ConsoleApp.DtoBlogs;
using PPMDotNetCore.ConsoleApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPMDotNetCore.ConsoleApp.EFCoreExamples
{
    public class AddDbContext : DbContext
    {
        public AddDbContext(DbContextOptions options) : base(options)
        {
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(ConnectionString.SqlConnectionStringBuilder.ConnectionString);
        //}
        public DbSet<BlogDto> Blogs { get; set; }
    }
}

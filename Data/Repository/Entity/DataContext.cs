﻿using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository.Entity
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<MaintenanceImp> Maintenance { get; set; }
    }
}

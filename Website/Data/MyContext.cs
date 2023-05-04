﻿using Bezeq.DAL;
using Microsoft.EntityFrameworkCore;

namespace Website.Data;

public class MyContext : DbContext {
    public MyContext(DbContextOptions<MyContext> options)
        : base(options) {
        ChangeTracker.AutoDetectChangesEnabled = false;
    }


    public DbSet<Customer> Customers { get; set; }
}

﻿using CleanCrud.Models;
using Microsoft.EntityFrameworkCore;

namespace CleanCrud.Data;

public class BookContext : DbContext
{
    public BookContext(DbContextOptions<BookContext> options)
        : base(options) { }

    public DbSet<Book> Books { get; set; }
}

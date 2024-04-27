using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Recipe.Library.Models;

namespace Recipe.Library.Context;

public partial class DataContext : DbContext
{
    public DataContext()
    {
    }

    public DataContext(DbContextOptions<DataContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Ingredient> Ingredients { get; set; }

    public virtual DbSet<Models.Recipe> Recipes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite("Data Source=C:\\Users\\tydi4\\source\\repos\\Recipe\\Recipe.Library\\Recipe.Library\\Database\\Recipe.db"); //Please replace this path with your local path

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ingredient>(entity =>
        {
            entity.Property(e => e.IngredientId).HasColumnName("IngredientID");
            entity.Property(e => e.RecipeId).HasColumnName("RecipeID");
        });

        modelBuilder.Entity<Models.Recipe>(entity =>
        {
            entity.Property(e => e.RecipeId).HasColumnName("RecipeID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

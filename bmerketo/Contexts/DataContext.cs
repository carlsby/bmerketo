using bmerketo.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace bmerketo.Contexts;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<ProductEntity> Products { get; set; }
    public DbSet<CategoryEntity> Category { get; set; }
    public DbSet<ContactEntity> Contacts { get; set; }
    public DbSet<CommentEntity> Comments { get; set; }
}

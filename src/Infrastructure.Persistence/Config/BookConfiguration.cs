using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Config
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("Books");
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Name).IsRequired().HasMaxLength(250);
            builder.Property(b => b.Category).IsRequired().HasMaxLength(250);
            builder.Property(b => b.Author).IsRequired().HasMaxLength(250);
            builder.Property(b => b.Price).IsRequired().HasColumnType("decimal(18,2)");
        }
    }
}

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.ToTable("Books");

        builder.Property(b => b.Id);
        
        builder.Property(b => b.Title)
            .IsRequired()
            .HasMaxLength(200);
        
        builder.Property(b => b.Author)
            .IsRequired()
            .HasMaxLength(100);
        
        builder.Property(b => b.ISBN)
            .IsRequired()
            .HasMaxLength(13);
        
        builder.Property(b => b.PublicationDate)
            .IsRequired();
        
        builder.Property(b => b.Price)
            .IsRequired();
    }
}
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class BookConfig : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.Property(b => b.Id).IsRequired();
            builder.Property(b => b.Name).IsRequired().HasMaxLength(150);
            builder.Property(b => b.Author).IsRequired().HasMaxLength(100);
            builder.Property(b => b.Article).IsRequired();
            builder.Property(b => b.PublishingYear).IsRequired();
            builder.Property(b => b.Count).IsRequired();
        }
    }
}
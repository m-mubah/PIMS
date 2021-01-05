using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PIMS.API.Domain.Entities;

namespace PIMS.API.Data.SchemaConfigurations
{
    public class AtollsSchemaConfiguration : IEntityTypeConfiguration<Atoll>
    {
        public void Configure(EntityTypeBuilder<Atoll> builder)
        {
            builder.ToTable("Atolls");
            builder.HasKey(k => k.Id);

            builder.Property(p => p.Name).IsRequired().HasMaxLength(60);
            builder.Property(p => p.Code).IsRequired().HasMaxLength(5);
            builder.Property(p => p.DeletedOn).HasDefaultValue(null);

            builder.HasIndex(i => i.Name).IsUnique();
            builder.HasIndex(i => i.Code).IsUnique();

            builder.HasQueryFilter(q => q.DeletedOn == null);

            builder.HasData(
                new Atoll {Id = 1, Name = "Haa Alif", Code = "H.A."},
                new Atoll { Id = 2, Name = "Haa Dhaalu", Code = "H.Dh." },
                new Atoll { Id = 3, Name = "Shaviyani", Code = "Sh." },
                new Atoll { Id = 4, Name = "Noonu", Code = "N." },
                new Atoll { Id = 5, Name = "Raa", Code = "R." },
                new Atoll { Id = 6, Name = "Baa", Code = "B." },
                new Atoll { Id = 7, Name = "Lhaviyani", Code = "Lh." }, 
                new Atoll { Id = 8, Name = "Kaafu", Code = "K." },
                new Atoll { Id = 9, Name = "North Ari", Code = "A.A." },
                new Atoll { Id = 10, Name = "South Ari", Code = "A.Dh." },
                new Atoll { Id = 11, Name = "Vaavu", Code = "V." },
                new Atoll { Id = 12, Name = "Meemu", Code = "M." },
                new Atoll { Id = 13, Name = "Faafu", Code = "F." },
                new Atoll { Id = 14, Name = "Dhaalu", Code = "Dh." },
                new Atoll { Id = 15, Name = "Thaa", Code = "Th." },
                new Atoll { Id = 16, Name = "Laamu", Code = "L." },
                new Atoll { Id = 17, Name = "Gaafu Alif", Code = "G.A." },
                new Atoll { Id = 18, Name = "Gaafu Dhaalu", Code = "G.Dh." },
                new Atoll { Id = 19, Name = "Gnaviyani", Code = "Gn." },
                new Atoll { Id = 20, Name = "Seenu", Code = "S." }
            );
        }
    }
}
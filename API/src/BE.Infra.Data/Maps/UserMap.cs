using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BE.Domain.Entities;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using BE.Domain.Objects;

namespace BE.Infra.Data.Maps
{
    public class UserMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(x => x.Id);




            var conversorCpf = new ValueConverter<Cpf, string>(p => p.ToString(), p => Cpf.Parse(p));

            builder.Property(x => x.Cpf)
                        .HasConversion(conversorCpf);



                        
        }
    }

}
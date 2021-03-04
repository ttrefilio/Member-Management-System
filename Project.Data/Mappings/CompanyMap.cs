using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Data.Mappings
{
    public class CompanyMap : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.Property(c => c.Name)
                .HasMaxLength(100)                
                .IsRequired();
        }
    }
}

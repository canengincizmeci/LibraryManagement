using LibraryManagement.Core.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.DataAccess.Concrete.EfCore.Configurations
{
    public class OperationClaimConfiguration : IEntityTypeConfiguration<OperationClaim>
    {
        public void Configure(EntityTypeBuilder<OperationClaim> builder)
        {
            builder.ToTable("OperationClaims");

            builder.HasKey(oc => oc.Id);
            builder.Property(oc => oc.Id).ValueGeneratedOnAdd();

            builder.Property(oc => oc.Name).IsRequired().HasMaxLength(200);

            builder.HasMany(oc => oc.UserOperationClaims).WithOne(uoc => uoc.OperationClaim).HasForeignKey(uoc => uoc.OperationClaimId);
        }
    }
}

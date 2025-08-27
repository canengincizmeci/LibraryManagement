using LibraryManagement.Core.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryManagement.DataAccess.Concrete.EfCore.Configurations
{
    public class UserOperationClaimConfiguration : IEntityTypeConfiguration<UserOperationClaim>
    {
        public void Configure(EntityTypeBuilder<UserOperationClaim> builder)
        {
            builder.ToTable("UserOperationClaim");

            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id).ValueGeneratedOnAdd();

            builder.HasOne(uoc => uoc.User).WithMany(u => u.UserOperationClaims).HasForeignKey(uoc => uoc.UserId);

            builder.HasOne(uoc => uoc.OperationClaim).WithMany(oc => oc.UserOperationClaims).HasForeignKey(uoc => uoc.OperationClaimId);

        }
    }
}

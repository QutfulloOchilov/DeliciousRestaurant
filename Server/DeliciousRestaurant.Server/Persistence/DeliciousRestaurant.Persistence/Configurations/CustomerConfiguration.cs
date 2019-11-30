using DeliciousRestaurant.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DeliciousRestaurant.Persistence.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(p => p.Id).HasColumnName(nameof(Customer.Id));
            builder.Property(p => p.Gender).HasColumnName(nameof(Customer.Gender));
            builder.Property(p => p.IdentityUserId).HasColumnName(nameof(Customer.IdentityUserId));
            builder.Property(p => p.Image).HasColumnName(nameof(Customer.Image));
            builder.Property(p => p.FirstName).HasColumnName(nameof(Customer.FirstName));
            builder.Property(p => p.LastName).HasColumnName(nameof(Customer.LastName));
        }
    }
}
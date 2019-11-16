using DeliciousRestaurant.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DeliciousRestaurant.Persistence.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(p => p.Id).HasColumnName(nameof(Customer.Id));
            builder.Property(p => p.Gender).HasColumnName(nameof(Customer.Gender));
            builder.Property(p => p.IdentityUserId).HasColumnName(nameof(Customer.IdentityUserId));
            builder.Property(p => p.Image).HasColumnName(nameof(Customer.Image));
            builder.Property(p => p.Name).HasColumnName(nameof(Customer.Name));
            builder.Property(p => p.LastName).HasColumnName(nameof(Customer.LastName));
        }
    }
}
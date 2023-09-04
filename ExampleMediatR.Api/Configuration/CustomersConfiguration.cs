namespace ExampleMediatR.Api.Configuration;

using ExampleMediatR.Api.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class CustomersConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.HasKey(c => c.Id);

        builder
            .HasMany(c => c.Orders)
            .WithOne(o => o.Customer)
            .HasForeignKey(c => c.Customer.Id) // is it good? or maybe additional property 'CustomerId' in Order.cs
            .IsRequired(false);
    }
}


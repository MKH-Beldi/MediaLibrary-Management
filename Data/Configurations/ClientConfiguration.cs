using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasOne(client => client.Category).WithMany(category => category.Clients).HasForeignKey(client => client.CategoryFK).
                OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(client => client.Documents).WithMany(document => document.Clients).UsingEntity<Borrow>(
                borrow => borrow.HasOne(borrow => borrow.Document).WithMany(document => document.Borrows).HasForeignKey(borrow => borrow.DocumentFK),
                borrow => borrow.HasOne(borrow => borrow.Client).WithMany(client => client.Borrows).HasForeignKey(borrow => borrow.ClientFK),
                borrow => borrow.HasKey(borrow => new { borrow.ClientFK, borrow.DocumentFK, borrow.BorrowDate })
                );
        }
    }
}

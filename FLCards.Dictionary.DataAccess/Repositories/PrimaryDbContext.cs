using FLCards.Cards.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace FLCards.Dictionary.DataAccess.Repositories
{
    internal class PrimaryDbContext : DbContext
    {
        public virtual DbSet<DictionaryEntity> Dictionary { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=FLCards_Dictionary;Trusted_Connection=True;");
        }
    }
}

using FLCards.Cards.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace FLCards.Cards.DataAccess.Repositories
{
	internal class PrimaryDbContext : DbContext
	{
		public virtual DbSet<CardEntity> Cards { get; set; }
		public virtual DbSet<DeckEntity> Decks { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=FLCards_Cards;Trusted_Connection=True;");
		}
	}
}

using System;

namespace FLCards.Cards.DataAccess.Entities
{
	internal sealed class DeckEntity
	{
		public Guid Id { get; set; }

		public Guid UserId { get; set; }

		public string Name { get; set; }

		public int Status { get; set; }
	}
}

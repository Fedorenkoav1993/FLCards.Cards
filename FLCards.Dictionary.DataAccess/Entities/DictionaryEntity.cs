using System;

namespace FLCards.Cards.DataAccess.Entities
{
	internal sealed class DictionaryEntity
	{
		public Guid Id { get; set; }

		public string English { get; set; }
		
		public string Russian { get; set; }
	}
}

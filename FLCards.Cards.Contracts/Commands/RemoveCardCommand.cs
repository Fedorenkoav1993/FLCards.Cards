using System;

namespace FLCards.Cards.Contracts.Commands
{
	public sealed class RemoveCardCommand
	{
		public Guid CardId { get; set; }
	}
}

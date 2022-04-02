using System;

namespace FLCards.Cards.Contracts.Commands
{
	public sealed class AddDeckCommand
	{
		public Guid UserId { get; set; }

		public string Name { get; set; }
	}
}

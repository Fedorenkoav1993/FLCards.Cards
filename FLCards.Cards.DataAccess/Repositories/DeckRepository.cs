using System;
using System.Linq;
using System.Threading.Tasks;
using FLCards.Cards.DataAccess.Entities;
using FLCards.Cards.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace FLCards.Cards.DataAccess.Repositories
{
	public class DeckRepository : IDeckRepository
	{
		public async Task<Deck> GetById(Guid deckId)
		{
			using (var context = new PrimaryDbContext())
			{
				var deckEntity = await context.Decks
					.Where(d => d.Id == deckId)
					.FirstAsync();

				var cards = (await context.Cards
					.Where(c => c.DeckId == deckId)
					.ToArrayAsync())
					.Select(ce =>
						new Card(
							ce.Id,
							new Phrase(ce.OriginalValue, ce.OriginalLanguage),
							new Phrase(ce.TranslationValue, ce.TranslationLanguage),
							!string.IsNullOrWhiteSpace(ce.ImageUri) ? new Uri(ce.ImageUri) : null))
					.ToList();

				return new Deck(
					deckEntity.Id,
					deckEntity.UserId,
					deckEntity.Name,
					(LearningProcessStatus)deckEntity.Status,
					cards);
			}
		}

		public async Task Add(Deck deck)
		{
			using (var context = new PrimaryDbContext())
			{
				await context.Decks.AddAsync(
					new DeckEntity
					{
						Id = deck.Id,
						Name = deck.Name,
						Status = (int)deck.LearningProcessStatus,
						UserId = deck.UserId
					});

				foreach (var card in deck.Cards)
				{
					await context.AddAsync(new CardEntity
					{
						Id = card.Id,
						DeckId = deck.Id,
						OriginalValue = card.Original.Value,
						OriginalLanguage = card.Original.Language,
						TranslationValue = card.Translation.Value,
						TranslationLanguage = card.Translation.Language,
						ImageUri = card.ImageUri?.AbsoluteUri
					});
				}

				await context.SaveChangesAsync();
			}
		}

		public async Task Update(Deck deck)
		{
			using (var context = new PrimaryDbContext())
			{
				context.Decks.Update(
					new DeckEntity
					{
						Id = deck.Id,
						Name = deck.Name,
						Status = (int)deck.LearningProcessStatus,
						UserId = deck.UserId
					});

				foreach (var card in deck.Cards)
				{
					context.Update(new CardEntity
					{
						Id = card.Id,
						DeckId = deck.Id,
						OriginalValue = card.Original.Value,
						OriginalLanguage = card.Original.Language,
						TranslationValue = card.Translation.Value,
						TranslationLanguage = card.Translation.Language,
						ImageUri = card.ImageUri?.AbsoluteUri
					});
				}

				await context.SaveChangesAsync();
			}
		}

		public async Task Remove(Guid deckId)
		{
			using (var context = new PrimaryDbContext())
			{
				var deck = context.Decks.First(d => d.Id == deckId);

				context.Decks.Remove(deck);
				await context.SaveChangesAsync();
			}
		}

		public async Task AddCard(Card card, Guid deckId)
		{
			using (var context = new PrimaryDbContext())
			{
				await context.Cards.AddAsync(
					new CardEntity
					{
						Id = card.Id,
						DeckId = deckId,
						OriginalValue = card.Original.Value,
						OriginalLanguage = card.Original.Language,
						TranslationValue = card.Translation.Value,
						TranslationLanguage = card.Translation.Language,
						ImageUri = card.ImageUri?.AbsoluteUri
					});

				await context.SaveChangesAsync();
			}
		}

		public async Task RemoveCard(Guid cardId)
		{
			using (var context = new PrimaryDbContext())
			{
				var card = context.Cards.First(d => d.Id == cardId);

				context.Cards.Remove(card);
				await context.SaveChangesAsync();
			}
		}

		public async Task<Deck[]> GetDecks(Guid userId)
		{
			using (var context = new PrimaryDbContext())
			{
				var decks = await context.Decks
					.Where(d => d.UserId == userId)
					.ToArrayAsync();

				return decks
					.Select(de => new Deck(de.Id, de.UserId, de.Name, (LearningProcessStatus)de.Status))
					.ToArray();
			}
		}

		public async Task<Card[]> GetCards(Guid deckId)
		{
			using (var context = new PrimaryDbContext())
			{
				var cards = await context.Cards
					.Where(c => c.DeckId == deckId)
					.ToArrayAsync();

				return cards
					.Select(ce => 
						new Card(
							ce.Id,
							new Phrase(ce.OriginalValue, ce.OriginalLanguage),
							new Phrase(ce.TranslationValue, ce.TranslationLanguage),
							!string.IsNullOrWhiteSpace(ce.ImageUri) ? new Uri(ce.ImageUri) : null))
					.ToArray();
			}
		}
	}
}

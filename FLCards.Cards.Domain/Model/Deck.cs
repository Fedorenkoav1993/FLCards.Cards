using FLCards.Cards.Domain.Model.Representations;
using FLCards.Common.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FLCards.Cards.Domain.Model
{
	public sealed class Deck
	{
		public Deck(
			Guid id,
			Guid userId,
			string name,
			LearningProcessStatus learningProcessStatus,
			IList<Card> cards)
		{
			Id = id;
			UserId = userId;
			Name = name;
			LearningProcessStatus = learningProcessStatus;

			Cards = cards;
		}

		public Deck(
			Guid id,
			Guid userId,
			string name,
			LearningProcessStatus learningProcessStatus)
		{
			Id = id;
			UserId = userId;
			Name = name;
			LearningProcessStatus = learningProcessStatus;

			Cards = new List<Card>();
		}

		public Guid Id { get; }

		public Guid UserId { get; }

		public string Name { get; }
		public LearningProcessStatus LearningProcessStatus { get; private set; }

		public IList<Card> Cards { get; }

		public static Deck Create(
			Guid userId,
			string name,
			IList<Card> cards = null)
        {
			return new Deck(
				Guid.NewGuid(),
				userId,
				name,
				LearningProcessStatus.NotStarted,
				cards);
        }

		public void AddCard(Card card)
		{
			Cards.Add(card);
		}

		public void RemoveCard(Guid cardId)
		{
			var card = Cards.FirstOrDefault(c => c.Id == cardId);

			Cards.Remove(card);
		}

		public Result<Representation, string> GetNextRepresentation(RepresentationType representationType)
		{
			if (LearningProcessStatus != LearningProcessStatus.WaitingForCardRequest && LearningProcessStatus != LearningProcessStatus.NotStarted)
			{
				return $"Status cannot be other than {LearningProcessStatus.WaitingForCardRequest}. Current status \"{LearningProcessStatus}\"";
			}

			LearningProcessStatus = LearningProcessStatus.WaitingForAnswer;

			switch (representationType)
			{
				case RepresentationType.PhraseInput:
					return CreatePhraseInputRepresentation();

				case RepresentationType.PhraseOptions:
					return CreatePhraseOptionsRepresentation();

				case RepresentationType.ReversePhraseInput:
					return CreateReversePhraseInputRepresentation();

				case RepresentationType.ReversePhraseOptions:
					return CreateReversePhraseOptionsRepresentation();

				default: return $"Unsupported RepresentationType : {representationType}";
			}
		}

		private PhraseOptionsRepresentation CreatePhraseOptionsRepresentation()
		{
			var cardsToLearn = Cards
				.Where(c => !c.IsLearningFinished())
				.ToList();

			var cardToLearnIndex = new Random().Next(cardsToLearn.Count - 1);

			var cardToLearn = cardsToLearn[cardToLearnIndex];

			// TODO: Get from dictionary
			var cardsForOptions = Cards
				.Where(c => c.Id != cardToLearn.Id)
				.Take(3)
				.Select(c => c.Translation)
				.ToList();
			
			cardsForOptions.Add(cardToLearn.Translation);

			return new PhraseOptionsRepresentation(
				cardToLearn.Original,
				cardsForOptions);
		}

		private PhraseInputRepresentation CreatePhraseInputRepresentation()
        {
			var cardsToLearn = Cards
				.Where(c => !c.IsLearningFinished())
				.ToList();

			var cardToLearnIndex = new Random().Next(cardsToLearn.Count - 1);

			var cardToLearn = cardsToLearn[cardToLearnIndex];

			return new PhraseInputRepresentation(cardToLearn.Original);
		}

		private ReversePhraseOptionsRepresentation CreateReversePhraseOptionsRepresentation()
		{
			var cardsToLearn = Cards
				.Where(c => !c.IsLearningFinished())
				.ToList();

			var cardToLearnIndex = new Random().Next(cardsToLearn.Count - 1);

			var cardToLearn = cardsToLearn[cardToLearnIndex];

			// TODO: Get from dictionary
			var cardsForOptions = Cards
				.Where(c => c.Id != cardToLearn.Id)
				.Take(3)
				.Select(c => c.Original)
				.ToList();

			cardsForOptions.Add(cardToLearn.Original);

			return new ReversePhraseOptionsRepresentation(
				cardToLearn.Translation,
				cardsForOptions);
		}

		private ReversePhraseInputRepresentation CreateReversePhraseInputRepresentation()
		{
			var cardsToLearn = Cards
				.Where(c => !c.IsLearningFinished())
				.ToList();

			var cardToLearnIndex = new Random().Next(cardsToLearn.Count - 1);

			var cardToLearn = cardsToLearn[cardToLearnIndex];

			return new ReversePhraseInputRepresentation(cardToLearn.Translation);
		}

		public Result<bool, string> AttachResult(Guid cardId, bool isSuccess)
		{
			if (LearningProcessStatus != LearningProcessStatus.WaitingForAnswer)
			{
				return $"Status cannot be other than {LearningProcessStatus.WaitingForAnswer}. Current status \"{LearningProcessStatus}\"";
			}

			var card = Cards.FirstOrDefault(c => c.Id == cardId);

			if (card == null)
			{
				return $"Cannot find card with CardId\"{cardId}\"";
			}

			card.AttachLearningAttempt(isSuccess);

			return true;
		}

		public void ResetLearningHistory()
		{
			foreach(var card in Cards)
			{
				card.ResetLearningHistory();
			}
		}
	}
}

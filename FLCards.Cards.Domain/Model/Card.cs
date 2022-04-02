using System;

namespace FLCards.Cards.Domain.Model
{
	public sealed class Card
	{
		public Card(
			Guid id,
			Phrase original,
			Phrase translation,
			Uri imageUri = null)
		{
			Id = id;
			Original = original;
			Translation = translation;
			ImageUri = imageUri;
		}

		public Guid Id { get; }

		public Phrase Original { get; }

		public Phrase Translation { get; }

		public Uri ImageUri { get; }

		public int FailedAttemptsCount { get; private set; }

		public int SuccessAttemptsCount { get; private set; }

		public static Card Create(
			Phrase original,
			Phrase translation,
			Uri imageUri = null)
		{
			return new Card(
				Guid.NewGuid(),
				original,
				translation,
				imageUri);
		}

		public void AttachLearningAttempt(bool isSuccess)
		{
			if (isSuccess)
			{
				SuccessAttemptsCount++;
			}
			else
			{
				FailedAttemptsCount++;
			}
		}

		public void ResetLearningHistory()
		{
			FailedAttemptsCount = 0;
			SuccessAttemptsCount = 0;
		}

		public bool IsLearningFinished()
		{
			return SuccessAttemptsCount - FailedAttemptsCount >= 5;
		}
	}
}

using System;
using System.Linq;
using System.Threading.Tasks;
using FLCards.Cards.Contracts.Queries;
using FLCards.Cards.DataAccess.Repositories;
using FLCards.Cards.Domain.Model.Representations;
using FLCards.Common.Infrastructure;

namespace FLCards.Cards.ApplicationServices.Services
{
	public sealed class LearningService : ILearningService
	{
		public LearningService(IDeckRepository deckRepository)
        {
            DeckRepository = deckRepository;
        }

		public IDeckRepository DeckRepository { get; }

		public async Task<Result<GetNextCardRepresentationQueryResult, string>> GetNextRepresentation(
			GetNextCardRepresentationQuery getNextCardRepresentationQuery)
		{
            try
            {
				var deck = await DeckRepository.GetById(Guid.Parse(getNextCardRepresentationQuery.DeckId));

				var representationResult = deck.GetNextRepresentation(MapRepresentationType(getNextCardRepresentationQuery.RepresentationType));

				await DeckRepository.Update(deck);

				if (representationResult.IsSuccess())
				{
					var successRepresentationResult = MapRepresentation(representationResult.SuccessResult);

					return new GetNextCardRepresentationQueryResult
					{
						RepresentationType = MapRepresentationType(representationResult.SuccessResult.Type),
						Representation = successRepresentationResult
					};
				}
				else
				{
					return representationResult.FailedResult;
				}
			}
			catch (Exception e)
			{
				return e.Message;
			}
		}

		private Contracts.Data.RepresentationDto MapRepresentation(Representation representation)
        {
			switch (representation.Type)
			{
				case RepresentationType.PhraseOptions:
					var phraseOptionsRepresentation = representation as PhraseOptionsRepresentation;

					return new Contracts.Data.PhraseOptionsRepresentationDto
					{
						Phrase = new Contracts.Data.PhraseDto
						{
							Value = phraseOptionsRepresentation.Phrase.Value,
							Language = phraseOptionsRepresentation.Phrase.Language
						},
						Options = phraseOptionsRepresentation.Options.Select(o => new Contracts.Data.PhraseDto
						{
							Value = o.Value,
							Language = o.Language
						}).ToArray()
					};

				case RepresentationType.PhraseInput:
					var phraseInputRepresentation = representation as PhraseInputRepresentation;

					return new Contracts.Data.PhraseInputRepresentationDto
					{
						Phrase = new Contracts.Data.PhraseDto
						{
							Value = phraseInputRepresentation.Phrase.Value,
							Language = phraseInputRepresentation.Phrase.Language
						}
					};

				case RepresentationType.ReversePhraseOptions:
					var reversePhraseOptionsRepresentation = representation as ReversePhraseOptionsRepresentation;

					return new Contracts.Data.ReversePhraseOptionsRepresentationDto
					{
						Phrase = new Contracts.Data.PhraseDto
						{
							Value = reversePhraseOptionsRepresentation.Phrase.Value,
							Language = reversePhraseOptionsRepresentation.Phrase.Language
						},
						Options = reversePhraseOptionsRepresentation.Options.Select(o => new Contracts.Data.PhraseDto
						{
							Value = o.Value,
							Language = o.Language
						}).ToArray()
					};

				case RepresentationType.ReversePhraseInput:
					var reversePhraseInputRepresentation = representation as ReversePhraseInputRepresentation;

					return new Contracts.Data.ReversePhraseInputRepresentationDto
					{
						Phrase = new Contracts.Data.PhraseDto
						{
							Value = reversePhraseInputRepresentation.Phrase.Value,
							Language = reversePhraseInputRepresentation.Phrase.Language
						}
					};

				default: throw new ArgumentOutOfRangeException();
			}
		}

		private RepresentationType MapRepresentationType(Contracts.Data.RepresentationType representationType)
        {
			return Enum.Parse<RepresentationType>(representationType.ToString());
        }

		private Contracts.Data.RepresentationType MapRepresentationType(RepresentationType representationType)
		{
			return Enum.Parse<Contracts.Data.RepresentationType>(representationType.ToString());
		}
	}
}

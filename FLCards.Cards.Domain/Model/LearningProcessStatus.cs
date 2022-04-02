namespace FLCards.Cards.Domain.Model
{
	public enum LearningProcessStatus
	{
		NotStarted = 0,

		WaitingForCardRequest = 10,

		WaitingForAnswer = 20,

		Completed = 30
	}
}

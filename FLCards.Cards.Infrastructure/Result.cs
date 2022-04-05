namespace FLCards.Common.Infrastructure
{
	public class Result<TSuccess, TFailed>
	{
		private Result(TSuccess success)
		{
			SuccessResult = success;
		}

		private Result(TFailed failed)
		{
			FailedResult = failed;
		}

		public TSuccess SuccessResult { get; }

		public TFailed FailedResult { get; }

		public bool IsSuccess()
		{
			return SuccessResult != null;
		}

		public static Result<TSuccess, TFailed> Success(TSuccess success)
		{
			return new Result<TSuccess, TFailed>(success);
		}

		public static Result<TSuccess, TFailed> Failed(TFailed failed)
		{
			return new Result<TSuccess, TFailed>(failed);
		}

		public static implicit operator TSuccess(Result<TSuccess, TFailed> result)
		{
			return result.SuccessResult;
		}

		public static implicit operator TFailed(Result<TSuccess, TFailed> result)
		{
			return result.FailedResult;
		}

		public static implicit operator Result<TSuccess, TFailed>(TSuccess success)
		{
			return Success(success);
		}

		public static implicit operator Result<TSuccess, TFailed>(TFailed failed)
		{
			return Failed(failed);
		}
	}
}

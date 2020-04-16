namespace Blog.Services.Models
{
    public class OperationResult<TResult>
    {
        public static OperationResult<TResult> CreateSuccessResult(TResult result)
        {
            return new OperationResult<TResult> { Success = true, Data = result };
        }

        public static OperationResult<TResult> CreateFailure(string message)
        {
            return new OperationResult<TResult> { Success = false, FailureMessage = message };
        }

        public bool Success { get; protected set; }
        public string FailureMessage { get; protected set; }

        public TResult Data { get; protected set; }
    }
}

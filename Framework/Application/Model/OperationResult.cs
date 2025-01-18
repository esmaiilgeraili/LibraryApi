using Newtonsoft.Json;

namespace Framework.Application.Model
{
    public class OperationResult
    {
        [JsonProperty("isSucceeded")]
        public bool IsSucceeded { get; private set; }

        [JsonProperty("message")]
        public string Message { get; private set; } = string.Empty;

        public OperationResult()
        {
            IsSucceeded = false;
        }

        public OperationResult Succeeded(string message = "عملیات با موفقیت انجام شد")
        {
            IsSucceeded = true;
            Message = message;
            return this;
        }

        public OperationResult Failed(string message)
        {
            IsSucceeded = false;
            Message = message;
            return this;
        }
    }
}

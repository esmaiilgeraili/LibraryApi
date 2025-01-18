using Newtonsoft.Json;

namespace Framework.Application.Model
{
    public class OperationResultWithData<T>
    {
        [JsonProperty("isSucceeded")]
        public bool IsSucceeded { get; private set; }

        [JsonProperty("message")]
        public string Message { get; private set; } = string.Empty;

        [JsonProperty("result")]
        public T? Result { get; set; }

        public OperationResultWithData()
        {
            IsSucceeded = false;
        }

        public OperationResultWithData<T> Succeeded(T result, string message = "عملیات با موفقیت انجام شد")
        {
            IsSucceeded = true;
            Message = message;
            Result = result;
            return this;
        }

        public OperationResultWithData<T> Failed(string message)
        {
            IsSucceeded = false;
            Message = message;
            Result = default(T);
            return this;
        }
    }
}
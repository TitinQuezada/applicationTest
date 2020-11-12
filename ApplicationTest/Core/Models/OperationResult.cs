using Core.Interfaces;

namespace Core.Models
{
    public sealed class OperationResult<T> : IOperationResult<T>
    {
        private OperationResult(string message, bool success, T entity)
        {
            Message = message;
            Success = success;
            Entity = entity;
        }

        public string Message { get; }

        public bool Success { get; }
        public T Entity { get; }

        public static OperationResult<T> Ok()
           => new OperationResult<T>("", true, default(T));
        public static OperationResult<T> Ok(T entity)
          => new OperationResult<T>("", true, entity);

        public static OperationResult<T> Fail(string message)
         => new OperationResult<T>(message, false, default(T));
    }
}

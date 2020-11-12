namespace Core.Interfaces
{
    public interface IOperationResult<T>
    {
        string Message { get; }
        bool Success { get; }
        T Entity { get; }
    }
}

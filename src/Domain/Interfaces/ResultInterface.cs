namespace Shared.Domain.Interfaces
{
  public interface IResultDomain<Type>
  {
    public Type Value { get; }
    public bool IsSuccess { get; }
    public string Error { get; }

    public IResultDomain<Type> Success(Type value);
    public IResultDomain<Type> Failure(string error, Type value);
  }
}

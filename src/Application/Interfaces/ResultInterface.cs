using Shared.Domain.Interfaces;

namespace Shared.Application.Interfaces
{
  public interface IResultApplication<Type> : IResultDomain<Type>
  {
    public new IResultApplication<Type> Success(Type value);
    public new IResultApplication<Type> Failure(string error, Type value);
  }
}

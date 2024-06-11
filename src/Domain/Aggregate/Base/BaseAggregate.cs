using Shared.Domain.Aggregate.Interfaces;
using Shared.Domain.Events.Interfaces;

namespace Shared.Domain.Aggregate.Base
{
  public abstract class BaseAggregateRoot(IEvent eventInterface) : IAggregateRoot
  {
    protected readonly IEvent _eventInterface = eventInterface;

    public void EmitEvent(string channel, string data)
    {
      _eventInterface.Emit(channel, data);
    }
  }
}

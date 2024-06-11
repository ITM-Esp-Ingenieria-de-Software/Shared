using Shared.Domain.Interfaces;
using Shared.Domain.ValueObjects;
using Shared.Domain.ValueObjects.Base;

namespace Shared.Domain.Aggregate.Helpers
{
  public abstract class BaseHelper
  {
    protected static IResultDomain<List<ErrorValueObject>> ValidateRecordFields(
      object data,
      IResultDomain<List<ErrorValueObject>> result
    )
    {
      var errors = new List<ErrorValueObject>();
      var type = data.GetType();

      foreach (var property in type.GetProperties())
      {
        var propertyValue = property.GetValue(data);

        if (propertyValue is BaseValueObjectErrorHandler baseValueObject)
        {
          if (!baseValueObject.IsValid())
          {
            errors.AddRange(baseValueObject.Errors);
          }
        }
      }

      return errors.Count > 0
        ? result.Failure("Invalid data structure", errors)
        : result.Success(errors);
    }
  }
}

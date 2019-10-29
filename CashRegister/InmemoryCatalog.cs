
using System;
using System.Collections;

namespace CashRegister
{
  public class InmemoryCatalog : IPriceQuery
  {
    private readonly ItemReference[] itemReferences;

    public InmemoryCatalog(params ItemReference[] itemReferences)
    {
      this.itemReferences = itemReferences;
    }
    Result IPriceQuery.FindPrice(string soughtItemCode)
    {
      return Aggregate<Result, ItemReference>(Result.NotFound(soughtItemCode), (result, itemReference) =>
      {
        if (itemReference.MatchSoughtItemCode(soughtItemCode))
        {
          return Result.Found(itemReference.GetUnitPrice());
        }
        else
        {
          return result;
        }
      }, itemReferences);
    }

    private static R Aggregate<R, T>(
      R identity,
      Func<R, T, R> reducer,
      IEnumerable elements)
    {
      var accumulator = identity;
      foreach (T element in elements)
      {
        accumulator = reducer(accumulator, element);
      }
      return accumulator;
    }
  }
}
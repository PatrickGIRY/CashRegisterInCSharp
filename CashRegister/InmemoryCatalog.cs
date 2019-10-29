
using System;
using System.Linq;
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
      var result = itemReferences
        .Where(itemReference => itemReference.MatchSoughtItemCode(soughtItemCode))
        .Select(itemReference => Result.Found(itemReference.GetUnitPrice()))
        .SingleOrDefault();
      return result ?? Result.NotFound(soughtItemCode);
    }
  }
}

using System.Collections.Generic;
using System.Linq;

namespace CashRegister
{
  public class InmemoryCatalog : IPriceQuery
  {
    private readonly Dictionary<string, Price> unitPricesByItemCode;


    public InmemoryCatalog(params ItemReference[] itemReferences)
    {
      this.unitPricesByItemCode = itemReferences.ToDictionary(
        itemReference => itemReference.ItemCode, 
        itemReference => itemReference.UnitPrice);
    }
    Result IPriceQuery.FindPrice(string soughtItemCode)
    {
      var price = unitPricesByItemCode.GetValueOrDefault(soughtItemCode);
      return price != null ? Result.Found(price) : Result.NotFound(soughtItemCode);
    }
  }
}
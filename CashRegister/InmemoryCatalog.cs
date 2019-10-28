
namespace CashRegister
{
  public class InmemoryCatalog : IPriceQuery
  {
    private readonly ItemReference[] itemReferences;

    public InmemoryCatalog(params ItemReference [] itemReferences) {
      this.itemReferences = itemReferences;
    }
    Price IPriceQuery.findPrice(string soughtItemCode)
    {
      foreach(var itemReference in itemReferences)
      {
        if (itemReference.MatchSoughtItemCode(soughtItemCode))
        {
          return itemReference.GetUnitPrice();
        }
      }
      return null;
    }
  }
}
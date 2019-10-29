
namespace CashRegister
{
  public class InmemoryCatalog : IPriceQuery
  {
    private readonly ItemReference[] itemReferences;

    public InmemoryCatalog(params ItemReference [] itemReferences) {
      this.itemReferences = itemReferences;
    }
    Result IPriceQuery.FindPrice(string soughtItemCode)
    {
      foreach(var itemReference in itemReferences)
      {
        if (itemReference.MatchSoughtItemCode(soughtItemCode))
        {
          return Result.Found(itemReference.GetUnitPrice());
        }
      }
      return Result.NotFound(soughtItemCode);
    }
  }
}
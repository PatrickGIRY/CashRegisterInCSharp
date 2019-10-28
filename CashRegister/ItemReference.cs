
namespace CashRegister
{
  public class ItemReference
  {
    private readonly string itemCode;
    private readonly Price unitPrice;

    public ItemReference(string itemCode, double unitPrice)
    {
      this.itemCode = itemCode;
      this.unitPrice = Price.ValueOf(unitPrice);
    }

    public bool MatchSoughtItemCode(string soughtItemCode)
    {
      return itemCode.Equals(soughtItemCode);
    }

    public Price GetUnitPrice()
    {
      return this.unitPrice;
    }
  }
}
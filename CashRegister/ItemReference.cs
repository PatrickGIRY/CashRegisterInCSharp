
namespace CashRegister
{
  public class ItemReference
  {
    private readonly string itemCode;
    private readonly Price unitPrice;

    public static Builder AReference()
    {
      return new Builder();
    }
    private ItemReference(string itemCode, Price unitPrice)
    {
      this.itemCode = itemCode;
      this.unitPrice = unitPrice;
    }

    public bool MatchSoughtItemCode(string soughtItemCode)
    {
      return itemCode.Equals(soughtItemCode);
    }

    public Price GetUnitPrice()
    {
      return this.unitPrice;
    }

    public class Builder
    {
      private string itemCode;
      private Price unitPrice;

      internal Builder()
      {
      }

      public Builder WithItemCode(string itemCode)
      {
        this.itemCode = itemCode;
        return this;
      }

      public Builder WithUnitPrice(double unitPrice)
      {
        return WithUnitPrice(Price.ValueOf(unitPrice));
      }

      public Builder WithUnitPrice(Price unitPrice)
      {
        this.unitPrice = unitPrice;
        return this;
      }

      public ItemReference Build()
      {
        return new ItemReference(itemCode, unitPrice);
      }
    }
  }
}
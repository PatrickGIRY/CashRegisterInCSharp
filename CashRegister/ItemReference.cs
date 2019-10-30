
namespace CashRegister
{
  public class ItemReference
  {
    public string ItemCode { get; private set; }
    public Price UnitPrice { get; private set; }

    public static Builder AReference()
    {
      return new Builder();
    }
    private ItemReference(string itemCode, Price unitPrice)
    {
      this.ItemCode = itemCode;
      this.UnitPrice = unitPrice;
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

namespace CashRegister
{
  public class Price
  {
    private readonly double value;

    public static Price ValueOf(double value) { return new Price(value); }

    private Price(double value) { this.value = value; }

    public static Price operator *(Price price, Quantity quantity)
    {
      return new Price(price.value * quantity);
    }

    public override bool Equals(object obj)
    {
      if (this == obj) return true;
      if (obj == null || this.GetType() != obj.GetType()) return false;
      Price price = obj as Price;
      return price.value.Equals(value);
    }

    public override string ToString()
    {
      return "Price{ value=" + value + '}';
    }

    public override int GetHashCode()
    {
      return value.GetHashCode();
    }
  }
}
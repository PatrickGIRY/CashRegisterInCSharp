
namespace CashRegister
{
  public interface IPriceQuery
  {
    Price findPrice(string itemCode);
  }
}
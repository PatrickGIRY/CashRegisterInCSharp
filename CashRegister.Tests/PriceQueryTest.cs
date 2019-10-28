using Microsoft.VisualStudio.TestTools.UnitTesting;
using NFluent;

namespace CashRegister.Tests
{
  [TestClass]
  public class PriceQueryTest
  {
    private IPriceQuery priceQuery;

    [TestInitialize]
    public void Initialize()
    {
      priceQuery = new InmemoryCatalog(
        new ItemReference("APPLE", 1.20),
        new ItemReference("BANANA", 1.90)
      );
    }

    [DataTestMethod]
    [DataRow("APPLE", 1.20)]
    [DataRow("BANANA", 1.90)]
    public void find_the_price_given_an_item_code(string itemCode, double unitPrice)
    {
      Check.That(priceQuery.findPrice(itemCode)).IsEqualTo(Price.ValueOf(unitPrice));
    }

    [TestMethod]
    public void search_an_unknow_item()
    {
      Check.That(priceQuery.findPrice("PEACH")).IsNull();
    }
  }
}
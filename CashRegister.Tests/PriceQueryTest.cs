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
        ItemReference.AReference().WithItemCode("APPLE").WithUnitPrice(1.20).Build(),
        ItemReference.AReference().WithItemCode("BANANA").WithUnitPrice(1.90).Build()
      );
    }

    [DataTestMethod]
    [DataRow("APPLE", 1.20)]
    [DataRow("BANANA", 1.90)]
    public void find_the_price_given_an_item_code(string itemCode, double unitPrice)
    {
      Check.That(priceQuery.FindPrice(itemCode)).IsEqualTo(Result.Found(Price.ValueOf(unitPrice)));
    }

    [TestMethod]
    public void search_an_unknow_item()
    {
      Check.That(priceQuery.FindPrice("PEACH")).IsEqualTo(Result.NotFound("PEACH"));
    }
  }
}
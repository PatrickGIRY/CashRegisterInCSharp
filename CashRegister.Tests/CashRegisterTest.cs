using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NFluent;

namespace CashRegister.Tests
{
  [TestClass]
  public class CashRegisterTest
  {
    private CashRegister cashRegister;

    private IPriceQuery priceQuery;

    [TestInitialize]
    public void Initialize()
    {
      priceQuery = new InmemoryCatalog(
        ItemReference.AReference().WithItemCode("APPLE").WithUnitPrice(1.20).Build(),
        ItemReference.AReference().WithItemCode("BANANA").WithUnitPrice(1.90).Build()
      );
      cashRegister = new CashRegister();
    }

    [DataTestMethod]
    [DataRow("APPLE", 1, 1.20)]
    [DataRow("BANANA", 1, 1.90)]
    public void total_is_product_of_quantity_by_item_price(string itemCode, double quantity, double unitPrice)
    {
      var result = priceQuery.FindPrice(itemCode);

      var total = cashRegister.Total(result, Quantity.ValueOf(quantity));

      Check.That(total).IsEqualTo(Result.Found(Price.ValueOf(quantity * unitPrice)));
    }

    public void total_not_found_when_item_price_not_found()
    {
      var result = priceQuery.FindPrice("PEACH");

      var total = cashRegister.Total(result, Quantity.ValueOf(1));

      Check.That(total).IsEqualTo(Result.NotFound("PEACH"));
    }
  }
}

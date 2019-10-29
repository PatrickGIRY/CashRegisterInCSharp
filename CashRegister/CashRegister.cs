using System;

namespace CashRegister
{
    public class CashRegister
    {
      public Result Total(Result unitPrice, Quantity quantity) 
      {
        return unitPrice.Select(price => price * quantity);
      }
    }
}
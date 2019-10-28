using System;

namespace CashRegister
{
    public class CashRegister
    {
      public Price Total(Price price, double quantity) 
      {
        return price * quantity;
      }
    }
}
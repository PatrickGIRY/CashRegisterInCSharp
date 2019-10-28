using System;

namespace CashRegister
{
    public class CashRegister
    {
      public Price Total(Price price, Quantity quantity) 
      {
        return price * quantity;
      }
    }
}
using System;

namespace CashRegister
{
  public abstract class Result
  {
    public static Result Found(Price price)
    {
      return new FoundCase(price);
    }

    public static Result NotFound(string invalidItemCode)
    {
      return new NotFoundCase(invalidItemCode);
    }

    internal abstract Result Select(Func<Price, Price> f);

    private sealed class FoundCase : Result
    {
      private Price price;

      internal FoundCase(Price price)
      {
        this.price = price;
      }

      internal override Result Select(Func<Price, Price> f)
      {
        return Found(f(this.price));
      }

      public override bool Equals(object obj)
      {
        if (this == obj) return true;
        if (obj == null || this.GetType() != obj.GetType()) return false;
        FoundCase found = obj as FoundCase;
        return found.price.Equals(price);
      }

      public override int GetHashCode()
      {
        return price.GetHashCode();
      }

      public override string ToString()
      {
        return "FoundCase{ price=" + price + '}';
      }
    }

    private sealed class NotFoundCase : Result
    {
      private string invalidItemCode;

      internal NotFoundCase(string invalidItemCode)
      {
        this.invalidItemCode = invalidItemCode;
      }

      internal override Result Select(Func<Price, Price> f)
      {
        return this;
      }

      public override bool Equals(object obj)
      {
        if (this == obj) return true;
        if (obj == null || this.GetType() != obj.GetType()) return false;
        NotFoundCase notFound = obj as NotFoundCase;
        return notFound.invalidItemCode.Equals(invalidItemCode);
      }

      public override int GetHashCode()
      {
        return invalidItemCode.GetHashCode();
      }

      public override string ToString()
      {
        return "NotFoundCase{ invalidItemCode=" + invalidItemCode + '}';
      }
    }
  }
}
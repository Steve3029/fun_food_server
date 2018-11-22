using System;
namespace FunFoodServer.Infrastructure
{
  public class DisposableBase : IDisposable
  {
    public DisposableBase()
    {
    }

    public void Dispose()
    {
      throw new NotImplementedException();
    }
  }
}

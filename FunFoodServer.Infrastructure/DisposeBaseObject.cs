using System;
namespace FunFoodServer.Infrastructure
{
  public abstract class DisposeBaseObject : IDisposable
  {
    ~DisposeBaseObject()
    {
      this.Dispose(false);
    }

    // implement this method to dispose specific resources
    protected abstract void Dispose(bool disposing);

    public void Dispose()
    {
      this.Dispose(true);
      GC.SuppressFinalize(this);
    }
  }
}

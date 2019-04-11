using FunFoodServer.Domain.Repositories;

namespace FunFoodServer.Application
{
  public abstract class ApplicationService
  {
    private readonly IRepositoryContext _context;

    protected ApplicationService(IRepositoryContext context)
    {
      this._context = context;
    }

    public IRepositoryContext Context { get { return this._context; } }
  }
}

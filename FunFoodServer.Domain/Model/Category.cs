
namespace FunFoodServer.Domain.Model
{
    public class Category : AggregateRoot
    {
      public string Name { set; get; }

      public string Description { set; get; }

      public override string ToString()
      {
        return this.Name;
      }
    }
}

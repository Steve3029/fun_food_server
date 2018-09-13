
namespace FunFoodServer.Domain.Model
{
    public class Category : AggregateRoot
    {
      public string name { set; get; }

      public string Description { set; get; }

      public override string ToString()
      {
        return this.name;
      }
    }
}

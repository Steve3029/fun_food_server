using System;
namespace FunFoodServer.WebApi.Helpers
{
  public class CloudinaryConfig
  {
    public string CloudName { get; set; }
    public string ApiKey { get; set; }
    public string ApiSecret { get; set; }
    public string TitleCoverFolder { get; set; }
    public string IngredientFolder { get; set; }
    public string ProcessFolder { get; set; }
  }
}

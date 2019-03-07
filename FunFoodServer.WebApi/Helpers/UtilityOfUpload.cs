using System;
namespace FunFoodServer.WebApi.Helpers
{
  public static class UtilityOfUpload
  {
    public static string GetFileExt(string fileName)
    {
      if (string.IsNullOrWhiteSpace(fileName))
        return "gif";
      if ((fileName.IndexOf('.') == -1))
        return "gif";
      var speratedNames = fileName.Split(".");
      return speratedNames[speratedNames.Length - 1];
    }
  }
}

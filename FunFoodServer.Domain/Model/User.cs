using System;
using System.Collections.Generic;
using System.Text;

namespace FunFoodServer.Domain.Model
{
  public class User : AggregateRoot
  {
    public string UserName { set; get; }

    public string Password { set; get; }

    public string Email { set; get; }

    public UserProfile Profile {
      set
      {
        Profile = value;
      }
      get
      {
        // return a copy of profile
        return null;
      }
    }
  }
}


using System;

namespace FunFoodServer.Domain.Model
{
  public class User : IEntity
  {
    #region Properties
    public Guid Id { get; set; }

    public UserProfile Profile { get; set; }

    public string UserName { set; get; }

    public string Password { set; get; }

    public string Email { set; get; }

    public string PhotoUrl { get; set; }
    #endregion

    #region Public methods

    public override bool Equals(object obj)
    {
      if (obj == null)
        return false;
      if (ReferenceEquals(obj, this))
        return true;
      if (!(obj is UserProfile other))
        return false;
      return this.Id == other.Id;
    }

    public override int GetHashCode()
    {
      return this.Id.GetHashCode() ^
             this.Profile.GetHashCode() ^
             this.UserName.GetHashCode() ^
             this.Email.GetHashCode() ^
             this.Password.GetHashCode() ^
             this.PhotoUrl.GetHashCode();
    }
    #endregion
  }
}

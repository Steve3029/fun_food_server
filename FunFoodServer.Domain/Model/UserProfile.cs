using System;

namespace FunFoodServer.Domain.Model
{
    public class UserProfile : IEntity
    {
      #region Properties
      public Guid Id { get; set; }

      public Guid UserId { get; set; }

      public User User { get; set; }

      public string FirstName { get; set; }

      public string LastName { get; set; }

      public int Gender { get; set; }

      public DateTime Birthday { get; set; }

      public string Location { get; set; }

      public string GooglePlus { get; set; }

      public string Twitter { get; set; }

      public string Facebook { get; set; }

      public string Youtube { get; set; }
      #endregion

      #region
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
               this.FirstName.GetHashCode() ^
               this.LastName.GetHashCode() ^
               this.Gender.GetHashCode() ^
               this.Birthday.GetHashCode() ^
               this.Location.GetHashCode() ^
               this.GooglePlus.GetHashCode() ^
               this.Twitter.GetHashCode() ^
               this.Facebook.GetHashCode() ^
               this.Youtube.GetHashCode();
      }

      #endregion

    }
}

using System;
using System.Linq;
using Friends;
using Model;
using Xunit;

namespace IntegrationTests {
  public class FriendsControllerTests {
    [Fact]
    public void FriendsController_Returns_List_Of_Friends () {
      var ctrl = new FriendsController ();
      var friends = ctrl.Get ().ToList ();

      Assert.Equal (3, friends.Count ());

      Assert.Equal ("Joe", friends[0].Name);
      Assert.Equal ("Jane", friends[1].Name);
      Assert.Equal ("Jim", friends[2].Name);
    }
  }
}
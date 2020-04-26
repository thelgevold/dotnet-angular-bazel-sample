using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace Friends.Hubs {
  public class GreetingHub : Hub {
    public async Task SendMessage (string user) {
      await Clients.All.SendAsync ("ReceiveGreeting", $"Good Morning {user}");
    }
  }
}
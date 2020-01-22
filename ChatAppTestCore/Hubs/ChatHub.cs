using Microsoft.AspNetCore.SignalR;
using ChatAppTestCore.Models;
using System.Linq;
using System.Threading.Tasks;

namespace ChatAppTestCore.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(Message message) =>
    await Clients.All.SendAsync("receiveMessage", message);
    }
}

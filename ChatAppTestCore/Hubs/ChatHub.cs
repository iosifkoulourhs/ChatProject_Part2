using Microsoft.AspNetCore.SignalR;
using ChatAppTestCore.Models;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace ChatAppTestCore.Hubs
{
    public class ChatHub : Hub
    {
        static long counter = 0;

        public async Task SendMessage(Message message) =>
        await Clients.All.SendAsync("receiveMessage", message);


        public override Task OnConnectedAsync()
        {
            counter = counter = +1;
            Clients.All.SendAsync("UserConnected", Context.ConnectionId, counter);
            return base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            counter = counter - 1;
            await Clients.All.SendAsync(Context.ConnectionId, "Discone", counter);
            await base.OnDisconnectedAsync(exception);
        }
    }
}

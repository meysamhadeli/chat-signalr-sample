using Microsoft.AspNetCore.SignalR;

namespace SignalRChatApp.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendDataToApp1(string data)
        {
            await Clients.All.SendAsync("ReceiveDataInApp1", data);
        }

        public async Task SendDataToApp2(string data)
        {
            await Clients.All.SendAsync("ReceiveDataInApp2", data);
        }
    }
}

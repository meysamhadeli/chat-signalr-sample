using Microsoft.AspNetCore.SignalR;

namespace Application2.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendDataToApp1(string data)
        {
            try
            {
                await Clients.All.SendAsync("ReceiveDataInApp1", data);
            }
            catch (Exception ex)
            {
                await Clients.Caller.SendAsync("HandleError_ReceiveDataInApp1", $"An error occurred on the server: {ex}");
            }
        }

        public async Task SendDataToApp2(string data)
        {
            try
            {
                await Clients.All.SendAsync("ReceiveDataInApp2", data);
            }
            catch (Exception ex)
            {
                await Clients.Caller.SendAsync("HandleError_ReceiveDataInApp2", $"An error occurred on the server: {ex}");
            }
        }
    }
}

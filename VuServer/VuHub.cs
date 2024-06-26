using Microsoft.AspNetCore.SignalR;

namespace VuServer
{
    public class VuHub : Hub
    {
        public async Task SendVuData(int left, int right)
        {
            await Clients.All.SendAsync("UpdateVol", left, right);
        }
    }
}

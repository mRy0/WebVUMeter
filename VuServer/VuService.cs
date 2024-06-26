
using Microsoft.AspNetCore.SignalR;

namespace VuServer
{
    public class VuService(IHubContext<VuHub> vuHub, CoreAudioService coreAudioService) : BackgroundService
    {   
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var rnd =  new Random();    
            while(!stoppingToken.IsCancellationRequested)
            {
                await vuHub.Clients.All.SendAsync("UpdateVol", coreAudioService.DbValueLeft, coreAudioService.DbValueRight);


                await Task.Delay(20, stoppingToken);
            }
        }
    }
}

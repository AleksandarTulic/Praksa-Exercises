using Microsoft.AspNetCore.SignalR;

namespace SignalRSample.Hubs
{
    public class UserHub : Hub
    {
        public static int TotalViews { get; set; } = 0;

        public async Task NewWindowLoaded()
        {
            TotalViews++;
            //this is implemented ons erver now we need to tell the client value changed so you should change your value too
            //we are telling the client to call this method on his side so that he changes his/her values
            await Clients.All.SendAsync("updateTotalViews", TotalViews); //we can send as many values as we want



        }
    }
}

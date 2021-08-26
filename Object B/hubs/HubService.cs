using Microsoft.AspNetCore.SignalR;
using Object_B.Models.Context;
using System.Threading.Tasks;
using Object_B.Services;

namespace Object_B.hubs
{
    public class HubService : Hub
    {
        AllDataContext context;
        CreateVisitService visitService;
        public HubService(AllDataContext context, CreateVisitService visitService)
        {
            this.context = context;
            this.visitService = visitService;
        }
        public async Task SendMessage(string coordinates, string user)
        {
            await ListenCoordinates(coordinates);
            
            visitService.CreateVisits(Context.ConnectionId, coordinates, user);
            System.Console.WriteLine(coordinates + " : " + user);
        }

        public async Task ListenCoordinates(string coordinates)
        {
            var user = Context.ConnectionId;

            await Clients.All.SendAsync("ReceiveCoordinates", coordinates, user);
        }
    }
}

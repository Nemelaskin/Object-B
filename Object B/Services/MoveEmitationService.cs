using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using Object_B.Models.Context;
using System;
using System.Linq;
using System.Threading;

namespace Object_B.Services
{
    public class MoveEmitationService
    {
        static Timer t;
        public static async void EmitationMoveWorker(IHubContext<HubService> hubContext, AllDataContext context)
        {
            var sensocrs = context.Sensors.ToList();
            t = new Timer(async state => { 
                for(int i = 0; i < sensocrs.Count; i++)
                {
                    var coordinates = sensocrs[i].Coordinates.Split('.');
                    coordinates[0] = (Convert.ToInt32(coordinates[0]) - 10).ToString();
                    sensocrs[i].Coordinates = string.Join('.', coordinates);
                }
                var message = JsonConvert.SerializeObject(sensocrs);
                await hubContext.Clients.All.SendAsync("Receive", message);
            }, null, 100, 500);
            
            Console.WriteLine("test log");
        }
        public static void StopTimerSendForListeners()
        {
            t.Change(Timeout.Infinite, 0);
        }
    }
}

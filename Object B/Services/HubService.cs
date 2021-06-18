using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace Object_B.Services
{
    public class HubService : Hub
    {
        internal Task SendAsync(string v)
        {
            throw new NotImplementedException();
        }
    }
}

using Microsoft.AspNetCore.SignalR;
using Object_B.Models.Context;
using System.Linq;

namespace Object_B.hubs
{
    public class HubUserProvider : IUserIdProvider
    {
        AllDataContext context;

        public HubUserProvider(AllDataContext context)
        {
            this.context = context;
        }
        string IUserIdProvider.GetUserId(HubConnectionContext connection)
        {
            var users = context.Users.ToList();
            string user = "";
            foreach(var i in users)
            {
                if (i.IsActive == false) user = i.Email;
            }
            return user;
        }
    }
}

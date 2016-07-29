using System.Configuration;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace Chat.Hubs
{
    public class MessagesHub : Hub
    {
        private static string conString = ConfigurationManager.ConnectionStrings["testDB"].ToString();
        public void Hello()
        {
            Clients.All.hello();
        }

        [HubMethodName("sendMessages")]
        public static void SendMessages()
        {
            IHubContext context = GlobalHost.ConnectionManager.GetHubContext<MessagesHub>();
            context.Clients.All.updateMessages();
        }
    }

}
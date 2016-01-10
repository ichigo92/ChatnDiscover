using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using ChatnDiscover.Common;
using DataAccessLayer;

namespace ChatnDiscover
{
    [Authorize]
    public class ChatHub : Hub
    {

        #region Data Members

        static List<UserDetail> ConnectedUsers = new List<UserDetail>();
        static List<MessageDetail> CurrentMessage = new List<MessageDetail>();
        private readonly HubInstanceMethods _him;
        //public string UserName;
        private UserLogin ul = new UserLogin();

        #endregion


        //Functions that Client can all

        public ChatHub() : this(HubInstanceMethods.Instance) { }

        public ChatHub(HubInstanceMethods him)
        {
            _him = him;
        }

        //public void Connect(string username)
        //{
        //    ul=_him.Connect23(username);
        //   // Connect(ul.Username);
        //}

        //public void Connect()
        //{
        //    return _him.Connect();
        //}

        //Server Code that has a return value Stock
        //public IEnumerable<Stock> GetAllStocks()
        //{
        //    return _stockTicker.GetAllStocks();
        //}

        public void Connect(string userName)
        {
            _him.UserName = userName;
            //id can be taken from database
            var id = Context.ConnectionId;
            //UserLogin ul = new UserLogin(userName);
            //var id = Convert.ToString(ul.UserID);
           // string username=Clients.CallerState.userName;
            if (ConnectedUsers.Count(x => x.ConnectionId == id) == 0)
            {

                ConnectedUsers.Add(new UserDetail { ConnectionId = id, UserName = userName });

                // send to caller
                Clients.Caller.onConnected(id, userName, ConnectedUsers, CurrentMessage);

                // send to all except caller client
                Clients.AllExcept(id).onNewUserConnected(id, userName);

            }

        }

        public bool checkStatus(string username_two)
        {
            //string username_one=UserName;
            if (_him.checkStatus(username_two))
            {
                return true;
            }
            return false;
            
        }

        public void SendMessageToAll(string userName, string message)
        {
            // store last 100 messages in cache
            AddMessageinCache(userName, message);
            string username=Clients.CallerState.userName;
            Console.Write(username);
            // Broad cast message
            Clients.All.messageReceived(userName, message);
        }

        public void SendPrivateMessage(string toUserId, string message)
        {
            string fromUserId = Context.ConnectionId;

            var toUser = ConnectedUsers.FirstOrDefault(x => x.ConnectionId == toUserId);
            var fromUser = ConnectedUsers.FirstOrDefault(x => x.ConnectionId == fromUserId);

            if (toUser != null && fromUser != null)
            {
                // send to 
                Clients.Client(toUserId).sendPrivateMessage(fromUserId, fromUser.UserName, message);

                // send to caller user
                Clients.Caller.sendPrivateMessage(toUserId, fromUser.UserName, message);
            }
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            var item = ConnectedUsers.FirstOrDefault(x => x.ConnectionId == Context.ConnectionId);
            if (item != null)
            {
                ConnectedUsers.Remove(item);

                var id = Context.ConnectionId;
                Clients.All.onUserDisconnected(id, item.UserName);

            }
            return base.OnDisconnected(stopCalled);
        }

        #region private Messages

        private void AddMessageinCache(string userName, string message)
        {
            CurrentMessage.Add(new MessageDetail { UserName = userName, Message = message });

            if (CurrentMessage.Count > 100)
                CurrentMessage.RemoveAt(0);
        }

        #endregion

    }
}
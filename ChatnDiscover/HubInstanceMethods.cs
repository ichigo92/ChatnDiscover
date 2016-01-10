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
    public class HubInstanceMethods
    {
        string state;

        private readonly static Lazy<HubInstanceMethods> _instance = _instance = new Lazy<HubInstanceMethods>(() => new HubInstanceMethods(GlobalHost.ConnectionManager.GetHubContext<ChatHub>()));

        private IHubContext _context;

        public string UserName;

        UserLogin ul = new UserLogin();

        public HubInstanceMethods(IHubContext context)
        {
            _context = context;
        }
        public static HubInstanceMethods Instance
        {
            get
            {
                return _instance.Value;
            }
        }

        public bool checkStatus(string username_two)
        {
            UserFriend uf = new UserFriend();
            if (uf.checkStatus(UserName, username_two))
            {
                return true;
            }
            return false;
        }

        //public UserLogin Connect23(string username)
        //{
        //    UserLogin ul=new UserLogin(username);
        //    return ul;
        //}

        //public static HubInstanceMethods()
        //{
        //    _instance = new Lazy<HubInstanceMethods>(() => new HubInstanceMethods(GlobalHost.ConnectionManager.GetHubContext<ChatHub>()));
        //}

        //public void addkingpin(string username)
        //{
        //    _context.Clients.All.Connect(username);
        //}
    }
}
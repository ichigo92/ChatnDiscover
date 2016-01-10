using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Owin;
using Owin;
using ChatnDiscover;

[assembly: OwinStartup(typeof(ChatnDiscover.Startup))]
namespace ChatnDiscover
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}
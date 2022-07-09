using System;
using System.Linq;
using log4net;
using MiNET.Utils;
using OpenAPI;
using OpenAPI.Events;
using OpenAPI.Events.Player.PlayerJoinEvent;

namespace JoinText
{
    [
        OpenPluginInfo(
            Name = "JoinText", 
            Author = "hachkingtohach1", 
            Description = "Just join and have text"
        )
    ]
    public class JoinText : OpenPlugin, IEventHandler
    {
        private static readonly ILog Log = LogManager.GetLogger("Plugin is enabled!");
        
        internal OpenApi Api 
        { 
            get; 
        }
        
        public override void Enabled(OpenApi api)
        {
            api.EventDispatcher.RegisterEvents(this);
        }

        public override void Disabled(OpenApi api)
        {
            api.EventDispatcher.UnregisterEvents(this);
        }

        [EventHandler(EventPriority.Monitor)]
        public void OnPlayerJoin(PlayerJoinEvent e)
        {
            e.Player.SendMessage("Joined.");
        }
    }
}
// -----------------------------------------------------------------------
// <copyright file="WarheadEvents.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace BroadcastUtility.EventHandlers
{
    using Exiled.API.Features;
    using Exiled.Events.EventArgs;
    using WarheadHandlers = Exiled.Events.Handlers.Warhead;

    /// <summary>
    /// Handles events derived by <see cref="Exiled.Events.Handlers.Warhead"/>.
    /// </summary>
    public class WarheadEvents
    {
        private readonly Plugin plugin;

        /// <summary>
        /// Initializes a new instance of the <see cref="WarheadEvents"/> class.
        /// </summary>
        /// <param name="plugin">An instance of the <see cref="Plugin"/> class.</param>
        public WarheadEvents(Plugin plugin) => this.plugin = plugin;

        /// <summary>
        /// Subscribes to all required events.
        /// </summary>
        public void Subscribe()
        {
            WarheadHandlers.Starting += OnStarting;
            WarheadHandlers.Stopping += OnStopping;
        }

        /// <summary>
        /// Unsubscribes from all required events.
        /// </summary>
        public void Unsubscribe()
        {
            WarheadHandlers.Starting -= OnStarting;
            WarheadHandlers.Stopping -= OnStopping;
        }

        private void OnStarting(StartingEventArgs ev)
        {
            if (!ev.IsAllowed)
                return;

            Broadcast broadcast;
            if (ev.IsAuto || ev.Player == null)
            {
                broadcast = plugin.Config.WarheadConfig.AdminStartBroadcast;
                broadcast.Content = broadcast.Content.Replace("$time", Warhead.RealDetonationTimer.ToString());
                Map.Broadcast(broadcast);
                return;
            }

            broadcast = plugin.Config.WarheadConfig.StartBroadcast;
            broadcast.Content = broadcast.Content.Replace("$time", Warhead.RealDetonationTimer.ToString())
                .Replace("$user", ev.Player.DisplayNickname ?? ev.Player.Nickname);

            Map.Broadcast(broadcast);
        }

        private void OnStopping(StoppingEventArgs ev)
        {
            if (!ev.IsAllowed)
                return;

            if (ev.Player == null)
            {
                Map.Broadcast(plugin.Config.WarheadConfig.AdminCancelBroadcast);
                return;
            }

            Broadcast broadcast = plugin.Config.WarheadConfig.CancelBroadcast;
            broadcast.Content = broadcast.Content.Replace("$user", ev.Player.DisplayNickname ?? ev.Player.Nickname);
            Map.Broadcast(broadcast);
        }
    }
}
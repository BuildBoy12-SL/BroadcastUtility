// -----------------------------------------------------------------------
// <copyright file="Scp106Events.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace BroadcastUtility.EventHandlers
{
    using Exiled.Events.EventArgs;
    using UnityEngine;
    using Scp106Handlers = Exiled.Events.Handlers.Scp106;

    /// <summary>
    /// Handles events derived by <see cref="Exiled.Events.Handlers.Scp106"/>.
    /// </summary>
    public class Scp106Events
    {
        private readonly Plugin plugin;

        /// <summary>
        /// Initializes a new instance of the <see cref="Scp106Events"/> class.
        /// </summary>
        /// <param name="plugin">An instance of the <see cref="Plugin"/> class.</param>
        public Scp106Events(Plugin plugin) => this.plugin = plugin;

        /// <summary>
        /// Subscribes to all required events.
        /// </summary>
        public void Subscribe()
        {
            Scp106Handlers.Containing += OnContaining;
        }

        /// <summary>
        /// Unsubscribes from all required events.
        /// </summary>
        public void Unsubscribe()
        {
            Scp106Handlers.Containing -= OnContaining;
        }

        private void OnContaining(ContainingEventArgs ev)
        {
            if (Time.time - plugin.EnteredFemurTime <= plugin.Config.SecondsBeforeFemurActivation)
                ev.IsAllowed = false;
        }
    }
}
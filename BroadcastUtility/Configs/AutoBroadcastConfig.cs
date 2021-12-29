// -----------------------------------------------------------------------
// <copyright file="AutoBroadcastConfig.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace BroadcastUtility.Configs
{
    using System.ComponentModel;
    using Exiled.API.Features;

    /// <summary>
    /// Handles configuration of the looped auto-broadcast.
    /// </summary>
    public class AutoBroadcastConfig
    {
        /// <summary>
        /// Gets or sets the seconds between each broadcast.
        /// </summary>
        [Description("The seconds between each broadcast.")]
        public float Interval { get; set; } = 60f;

        /// <summary>
        /// Gets or sets the broadcast to send.
        /// </summary>
        [Description("The broadcast to send.")]
        public Broadcast Broadcast { get; set; } = new Broadcast("Join our discord!");
    }
}
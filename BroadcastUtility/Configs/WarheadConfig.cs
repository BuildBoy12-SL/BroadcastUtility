// -----------------------------------------------------------------------
// <copyright file="WarheadConfig.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace BroadcastUtility.Configs
{
    using System.ComponentModel;
    using Exiled.API.Features;

    /// <summary>
    /// Handles configuration in relation to warhead functionality.
    /// </summary>
    public class WarheadConfig
    {
        /// <summary>
        /// Gets or sets the broadcast to display when the warhead is started by a command or by an auto-nuke.
        /// </summary>
        [Description("The broadcast to display when the warhead is started by a command or by an auto-nuke. Available Variables: $time")]
        public Broadcast AdminStartBroadcast { get; set; } = new Broadcast("The warhead has been started!\nRemaining Time: $time", 7);

        /// <summary>
        /// Gets or sets the broadcast to display when the warhead is started by a player.
        /// </summary>
        [Description("The broadcast to display when the warhead is started by a player. Available Variables: $time, $user")]
        public Broadcast StartBroadcast { get; set; } = new Broadcast("The warhead has been started by $user!\nRemaining Time: $time", 7);

        /// <summary>
        /// Gets or sets the broadcast to display when the warhead is cancelled by a command.
        /// </summary>
        [Description("The broadcast to display when the warhead is cancelled by a command.")]
        public Broadcast AdminCancelBroadcast { get; set; } = new Broadcast("The warhead has been cancelled", 7);

        /// <summary>
        /// Gets or sets the broadcast to display when the warhead is cancelled by a player.
        /// </summary>
        [Description("The broadcast to display when the warhead is cancelled by a player. Available Variables: $user")]
        public Broadcast CancelBroadcast { get; set; } = new Broadcast("The warhead has been cancelled by $user", 7);
    }
}
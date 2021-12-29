// -----------------------------------------------------------------------
// <copyright file="ScpTerminationConfig.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace BroadcastUtility.Configs
{
    using System.ComponentModel;
    using Exiled.API.Features;

    /// <summary>
    /// Handles configuration in relation to scp terminations.
    /// </summary>
    public class ScpTerminationConfig
    {
        /// <summary>
        /// Gets or sets the broadcast to display when an scp subject is terminated by another player.
        /// </summary>
        [Description("The broadcast to display when an scp subject is terminated by another player. Available Variables: $scptype, $killername, $killerrolecolor, $killerteam")]
        public Broadcast ScpTerminationBroadcast { get; set; } = new Broadcast("$scptype was terminated by $killername who is a <color=$killerrolecolor>$killerteam</color>");

        /// <summary>
        /// Gets or sets the broadcast to display when an scp subject is terminated.
        /// </summary>
        [Description("The broadcast to display when an scp subject is terminated. Available Variables: $scptype, $scpusername")]
        public Broadcast ScpSuicideBroadcast { get; set; } = new Broadcast("$scpusername ($scptype) committed suicide");
    }
}
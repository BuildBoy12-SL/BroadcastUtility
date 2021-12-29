// -----------------------------------------------------------------------
// <copyright file="TeamRespawnConfig.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace BroadcastUtility.Configs
{
    using System.ComponentModel;
    using Exiled.API.Features;

    /// <summary>
    /// Handles configuration in relation to team respawning.
    /// </summary>
    public class TeamRespawnConfig
    {
        /// <summary>
        /// Gets or sets the broadcast to display when the mtf spawn.
        /// </summary>
        [Description("The broadcast to play when the mtf spawn. Available Variables: $unit, $num, $scps")]
        public Broadcast MtfSpawnBroadcast { get; set; } = new Broadcast("The MTF unit designated $unit-$num has spawned.\n$scps scps remain.");

        /// <summary>
        /// Gets or sets the broadcast to display when the chaos insurgency spawn.
        /// </summary>
        [Description("The broadcast to display when the chaos insurgency spawn.")]
        public Broadcast ChaosSpawnBroadcast { get; set; } = new Broadcast("The chaos insurgency have spawned!");

        /// <summary>
        /// Gets or sets a value indicating whether the <see cref="ChaosSpawnBroadcast"/> should only show to players on the chaos insurgency side.
        /// </summary>
        [Description("Whether the chaos spawn broadcast should only show to players on the chaos insurgency side.")]
        public bool ShowChaosClassdOnly { get; set; } = true;
    }
}
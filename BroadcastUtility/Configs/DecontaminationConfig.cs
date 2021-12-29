// -----------------------------------------------------------------------
// <copyright file="DecontaminationConfig.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace BroadcastUtility.Configs
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using Exiled.API.Features;

    /// <summary>
    /// Handles configuration in relation to decontamination announcements.
    /// </summary>
    public class DecontaminationConfig
    {
        /// <summary>
        /// Gets or sets the broadcasts that will occur throughout the round until decontamination activates.
        /// </summary>
        [Description("The broadcasts that will occur throughout the round until decontamination activates.")]
        public Dictionary<int, Broadcast> TimedBroadcasts { get; set; } = new Dictionary<int, Broadcast>
        {
            { 0, new Broadcast("Decontamination will commence in T-15 Minutes") },
            { 1, new Broadcast() },
            { 2, new Broadcast() },
            { 3, new Broadcast() },
            { 4, new Broadcast() },
        };

        /// <summary>
        /// Gets or sets the broadcast to display when decontamination has started.
        /// </summary>
        [Description("The broadcast to display when decontamination has started.")]
        public Broadcast DecontaminationStartedBroadcast { get; set; } = new Broadcast("Decontamination has begun!");
    }
}
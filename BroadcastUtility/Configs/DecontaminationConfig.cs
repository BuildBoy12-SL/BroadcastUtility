// -----------------------------------------------------------------------
// <copyright file="DecontaminationConfig.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace BroadcastUtility.Configs
{
    using System.ComponentModel;
    using Exiled.API.Features;

    /// <summary>
    /// Handles configuration in relation to decontamination announcements.
    /// </summary>
    public class DecontaminationConfig
    {
        /// <summary>
        /// Gets or sets the broadcast to display when decontamination has started.
        /// </summary>
        [Description("The broadcast to display when decontamination has started.")]
        public Broadcast DecontaminationStartedBroadcast { get; set; } = new Broadcast("Decontamination has begun!");
    }
}
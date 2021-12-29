// -----------------------------------------------------------------------
// <copyright file="SpawnProtectionHintConfig.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace BroadcastUtility.Configs
{
    using System.ComponentModel;

    /// <summary>
    /// Handles configuration in relation to the spawn protection hint.
    /// </summary>
    public class SpawnProtectionHintConfig
    {
        /// <summary>
        /// Gets or sets a value indicating whether the hint is enabled.
        /// </summary>
        [Description("Whether the hint is enabled.")]
        public bool IsEnabled { get; set; } = true;

        /// <summary>
        /// Gets or sets the message to show a user.
        /// </summary>
        [Description("The message to show a user.")]
        public string Content { get; set; } = "You are protected for $seconds seconds";
    }
}
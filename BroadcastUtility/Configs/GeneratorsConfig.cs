// -----------------------------------------------------------------------
// <copyright file="GeneratorsConfig.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace BroadcastUtility.Configs
{
    using System.ComponentModel;
    using Exiled.API.Features;

    /// <summary>
    /// Handles configuration in relation to generator activation.
    /// </summary>
    public class GeneratorsConfig
    {
        /// <summary>
        /// Gets or sets the broadcast to send when a generator is activated.
        /// </summary>
        [Description("The broadcast to send when a generator is activated. Available Variables: $generators")]
        public Broadcast GeneratorActivatedBroadcast { get; set; } = new Broadcast("$generators generators have been activated");

        /// <summary>
        /// Gets or sets the broadcast to send when all generators have been activated.
        /// </summary>
        [Description("The broadcast to send when all generators have been activated.")]
        public Broadcast AllGeneratorsActivatedBroadcast { get; set; } = new Broadcast("All generators have been activated!");
    }
}
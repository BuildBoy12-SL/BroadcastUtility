﻿// -----------------------------------------------------------------------
// <copyright file="Plugin.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace BroadcastUtility
{
    using System;
    using BroadcastUtility.EventHandlers;
    using Exiled.API.Enums;
    using Exiled.API.Features;

    /// <summary>
    /// The main plugin class.
    /// </summary>
    public class Plugin : Plugin<Config>
    {
        private PlayerEvents playerEvents;
        private MapEvents mapEvents;
        private ServerEvents serverEvents;
        private WarheadEvents warheadEvents;

        /// <summary>
        /// Gets the only existing instance of the <see cref="Plugin"/> class.
        /// </summary>
        public static Plugin Instance { get; private set; }

        /// <summary>
        /// Gets or sets the amount of mtf that spawned during the round.
        /// </summary>
        public int MtfSpawned { get; set; }

        /// <inheritdoc />
        public override string Author { get; } = "Build";

        /// <inheritdoc />
        public override string Name { get; } = "BroadcastUtility";

        /// <inheritdoc/>
        public override string Prefix { get; } = "BroadcastUtility";

        /// <inheritdoc />
        public override PluginPriority Priority { get; } = PluginPriority.Lower;

        /// <inheritdoc/>
        public override Version RequiredExiledVersion { get; } = new Version(4, 1, 7);

        /// <inheritdoc/>
        public override Version Version { get; } = new Version(1, 0, 0);

        /// <inheritdoc />
        public override void OnEnabled()
        {
            Instance = this;

            playerEvents = new PlayerEvents(this);
            playerEvents.Subscribe();
            mapEvents = new MapEvents(this);
            mapEvents.Subscribe();
            serverEvents = new ServerEvents(this);
            serverEvents.Subscribe();
            warheadEvents = new WarheadEvents(this);
            warheadEvents.Subscribe();

            base.OnEnabled();
        }

        /// <inheritdoc />
        public override void OnDisabled()
        {
            playerEvents.Unsubscribe();
            playerEvents = null;
            mapEvents.Unsubscribe();
            mapEvents = null;
            serverEvents.Unsubscribe();
            serverEvents = null;
            warheadEvents.Unsubscribe();
            warheadEvents = null;

            Instance = null;

            base.OnDisabled();
        }
    }
}
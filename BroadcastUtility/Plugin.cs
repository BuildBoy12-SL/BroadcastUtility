// -----------------------------------------------------------------------
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
    using RemoteAdmin;

    /// <summary>
    /// The main plugin class.
    /// </summary>
    public class Plugin : Plugin<Config>
    {
        private PlayerEvents playerEvents;
        private MapEvents mapEvents;
        private Scp106Events scp106Events;
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

        /// <summary>
        /// Gets or sets the time that the femur was entered.
        /// </summary>
        public float EnteredFemurTime { get; set; }

        /// <inheritdoc />
        public override string Author => "Build";

        /// <inheritdoc />
        public override string Name => "BroadcastUtility";

        /// <inheritdoc/>
        public override string Prefix => "BroadcastUtility";

        /// <inheritdoc />
        public override PluginPriority Priority => PluginPriority.Lower;

        /// <inheritdoc/>
        public override Version RequiredExiledVersion { get; } = new Version(5, 0, 0);

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
            scp106Events = new Scp106Events(this);
            scp106Events.Subscribe();
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
            scp106Events.Unsubscribe();
            scp106Events = null;
            serverEvents.Unsubscribe();
            serverEvents = null;
            warheadEvents.Unsubscribe();
            warheadEvents = null;

            Instance = null;

            base.OnDisabled();
        }

        /// <inheritdoc />
        public override void OnRegisteringCommands()
        {
            QueryProcessor.DotCommandHandler.RegisterCommand(Config.ScpListConfig);
        }

        /// <inheritdoc />
        public override void OnUnregisteringCommands()
        {
            QueryProcessor.DotCommandHandler.UnregisterCommand(Config.ScpListConfig);
        }
    }
}
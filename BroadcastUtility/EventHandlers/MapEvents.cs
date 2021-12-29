// -----------------------------------------------------------------------
// <copyright file="MapEvents.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace BroadcastUtility.EventHandlers
{
    using Exiled.API.Features;
    using Exiled.Events.EventArgs;
    using MapHandlers = Exiled.Events.Handlers.Map;

    /// <summary>
    /// Handles events derived by <see cref="Exiled.Events.Handlers.Map"/>.
    /// </summary>
    public class MapEvents
    {
        private readonly Plugin plugin;

        /// <summary>
        /// Initializes a new instance of the <see cref="MapEvents"/> class.
        /// </summary>
        /// <param name="plugin">An instance of the <see cref="Plugin"/> class.</param>
        public MapEvents(Plugin plugin) => this.plugin = plugin;

        /// <summary>
        /// Subscribes to all required events.
        /// </summary>
        public void Subscribe()
        {
            MapHandlers.AnnouncingDecontamination += OnAnnouncingDecontamination;
            MapHandlers.AnnouncingNtfEntrance += OnAnnouncingNtfEntrance;
            MapHandlers.Decontaminating += OnDecontaminating;
            MapHandlers.GeneratorActivated += OnGeneratorActivated;
        }

        /// <summary>
        /// Unsubscribes from all required events.
        /// </summary>
        public void Unsubscribe()
        {
            MapHandlers.AnnouncingDecontamination -= OnAnnouncingDecontamination;
            MapHandlers.AnnouncingNtfEntrance -= OnAnnouncingNtfEntrance;
            MapHandlers.Decontaminating -= OnDecontaminating;
            MapHandlers.GeneratorActivated -= OnGeneratorActivated;
        }

        private void OnAnnouncingDecontamination(AnnouncingDecontaminationEventArgs ev)
        {
            if (plugin.Config.DecontaminationConfig.TimedBroadcasts.TryGetValue(ev.Id, out Broadcast broadcast))
                Map.Broadcast(broadcast);
        }

        private void OnAnnouncingNtfEntrance(AnnouncingNtfEntranceEventArgs ev)
        {
            Broadcast broadcast = plugin.Config.TeamRespawnConfig.MtfSpawnBroadcast;
            string message = broadcast.Content.Replace("$unit", ev.UnitName)
                .Replace("$num", ev.UnitNumber.ToString())
                .Replace("$scps", ev.ScpsLeft.ToString());

            Map.Broadcast(broadcast.Duration, message, broadcast.Type, broadcast.Show);
        }

        private void OnDecontaminating(DecontaminatingEventArgs ev)
        {
            if (ev.IsAllowed)
                Map.Broadcast(plugin.Config.DecontaminationConfig.DecontaminationStartedBroadcast);
        }

        private void OnGeneratorActivated(GeneratorActivatedEventArgs ev)
        {
            if (!ev.IsAllowed)
                return;

            if (Map.ActivatedGenerators == 2)
            {
                Map.Broadcast(plugin.Config.GeneratorsConfig.AllGeneratorsActivatedBroadcast);
                return;
            }

            Broadcast broadcast = plugin.Config.GeneratorsConfig.GeneratorActivatedBroadcast;
            string message = broadcast.Content.Replace("$generators", (Map.ActivatedGenerators + 1).ToString());
            Map.Broadcast(broadcast.Duration, message, broadcast.Type, broadcast.Show);
        }
    }
}
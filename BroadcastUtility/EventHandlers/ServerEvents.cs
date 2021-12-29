// -----------------------------------------------------------------------
// <copyright file="ServerEvents.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace BroadcastUtility.EventHandlers
{
    using System.Collections.Generic;
    using System.Linq;
    using BroadcastUtility.API;
    using Exiled.API.Enums;
    using Exiled.API.Features;
    using Exiled.Events.EventArgs;
    using MEC;
    using Respawning;
    using ServerHandlers = Exiled.Events.Handlers.Server;

    /// <summary>
    /// Handles events derived by <see cref="Exiled.Events.Handlers.Server"/>.
    /// </summary>
    public class ServerEvents
    {
        private readonly Plugin plugin;
        private CoroutineHandle autoBroadcast;

        /// <summary>
        /// Initializes a new instance of the <see cref="ServerEvents"/> class.
        /// </summary>
        /// <param name="plugin">An instance of the <see cref="Plugin"/> class.</param>
        public ServerEvents(Plugin plugin) => this.plugin = plugin;

        /// <summary>
        /// Subscribes to all required events.
        /// </summary>
        public void Subscribe()
        {
            ServerHandlers.RespawningTeam += OnRespawningTeam;
            ServerHandlers.RoundEnded += OnRoundEnded;
            ServerHandlers.RoundStarted += OnRoundStart;
            ServerHandlers.WaitingForPlayers += OnWaitingForPlayers;
        }

        /// <summary>
        /// Unsubscribes from all required events.
        /// </summary>
        public void Unsubscribe()
        {
            ServerHandlers.RespawningTeam -= OnRespawningTeam;
            ServerHandlers.RoundEnded -= OnRoundEnded;
            ServerHandlers.RoundStarted -= OnRoundStart;
            ServerHandlers.WaitingForPlayers -= OnWaitingForPlayers;
        }

        private void OnRespawningTeam(RespawningTeamEventArgs ev)
        {
            if (!ev.IsAllowed || ev.NextKnownTeam != SpawnableTeamType.ChaosInsurgency)
                return;

            Broadcast broadcast = plugin.Config.TeamRespawnConfig.ChaosSpawnBroadcast;
            if (!plugin.Config.TeamRespawnConfig.ShowChaosClassdOnly)
            {
                Map.Broadcast(broadcast);
                return;
            }

            foreach (Player player in Player.Get(Side.ChaosInsurgency))
                player.Broadcast(broadcast);
        }

        private void OnRoundEnded(RoundEndedEventArgs ev)
        {
            Broadcast broadcast = plugin.Config.RoundEndedBroadcast;
            string message = broadcast.Content.Replace("$classdescape", RoundSummary.EscapedClassD.ToString())
                .Replace("$sciescape", RoundSummary.EscapedScientists.ToString())
                .Replace("$scpkills", RoundSummary.KilledBySCPs.ToString()
                .Replace("$mtfspawn", plugin.MtfSpawned.ToString()));

            Map.Broadcast(broadcast.Duration, message, broadcast.Type, broadcast.Show);
        }

        private void OnRoundStart()
        {
            autoBroadcast = Timing.RunCoroutine(RunAutoBroadcast());
            Timing.CallDelayed(1f, () =>
            {
                List<Player> scps = Player.Get(Team.SCP).ToList();

                Broadcast broadcast = plugin.Config.ScpSpawnBroadcast;
                string message = broadcast.Content.Replace("$scplist", string.Join(", ", scps.Select(player => player.Role.Translation())));

                foreach (Player player in scps)
                    player.Broadcast(broadcast.Duration, message, broadcast.Type, broadcast.Show);
            });
        }

        private void OnWaitingForPlayers()
        {
            if (autoBroadcast.IsRunning)
                Timing.KillCoroutines(autoBroadcast);

            plugin.MtfSpawned = 0;
            plugin.EnteredFemurTime = 0f;
        }

        private IEnumerator<float> RunAutoBroadcast()
        {
            while (true)
            {
                yield return Timing.WaitForSeconds(plugin.Config.AutoBroadcastConfig.Interval);
                Map.Broadcast(plugin.Config.AutoBroadcastConfig.Broadcast);
            }
        }
    }
}
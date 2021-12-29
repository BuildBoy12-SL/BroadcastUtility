// -----------------------------------------------------------------------
// <copyright file="PlayerEvents.cs" company="Build">
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
    using Exiled.API.Extensions;
    using Exiled.API.Features;
    using Exiled.Events.EventArgs;
    using MEC;
    using PlayerHandlers = Exiled.Events.Handlers.Player;

    /// <summary>
    /// Handles events derived by <see cref="Exiled.Events.Handlers.Player"/>.
    /// </summary>
    public class PlayerEvents
    {
        private readonly Plugin plugin;

        /// <summary>
        /// Initializes a new instance of the <see cref="PlayerEvents"/> class.
        /// </summary>
        /// <param name="plugin">An instance of the <see cref="Plugin"/> class.</param>
        public PlayerEvents(Plugin plugin) => this.plugin = plugin;

        /// <summary>
        /// Subscribes to all required events.
        /// </summary>
        public void Subscribe()
        {
            PlayerHandlers.ChangingRole += OnChangingRole;
            PlayerHandlers.Dying += OnDying;
            PlayerHandlers.EnteringFemurBreaker += OnEnteringFemurBreaker;
            PlayerHandlers.Verified += OnVerified;
        }

        /// <summary>
        /// Unsubscribes from all required events.
        /// </summary>
        public void Unsubscribe()
        {
            PlayerHandlers.ChangingRole -= OnChangingRole;
            PlayerHandlers.Dying -= OnDying;
            PlayerHandlers.EnteringFemurBreaker -= OnEnteringFemurBreaker;
            PlayerHandlers.Verified -= OnVerified;
        }

        private void OnChangingRole(ChangingRoleEventArgs ev)
        {
            if (ev.NewRole.GetTeam() == Team.MTF)
                plugin.MtfSpawned++;

            if (ev.IsAllowed && CharacterClassManager.EnableSP && plugin.Config.SpawnProtectionHintConfig.IsEnabled && CharacterClassManager.SProtectedTeam.Contains((int)ev.NewRole.GetTeam()))
                Timing.RunCoroutine(RunSpawnProtectionHint(ev.Player));
        }

        private void OnDying(DyingEventArgs ev)
        {
            if (!ev.IsAllowed)
                return;

            if (ev.Target.IsScp)
                ShowScpTerminationBroadcast(ev);

            if (Player.Get(ev.Target.Side).Count() == 2 &&
                plugin.Config.LastPersonnelBroadcasts.TryGetValue(ev.Target.Side, out Broadcast broadcast))
            {
                Map.Broadcast(broadcast);
            }

            if (ev.Target.Role == RoleType.ClassD && Player.Get(RoleType.ClassD).Count() == 1)
            {
                foreach (Player chaos in Player.Get(Side.ChaosInsurgency))
                    chaos.Broadcast(plugin.Config.AllClassdHaveBeenKilledBroadcast);
            }
        }

        private void OnEnteringFemurBreaker(EnteringFemurBreakerEventArgs ev)
        {
            if (!ev.IsAllowed)
                return;

            Broadcast broadcast = plugin.Config.FemurBreakerEnteredBroadcast;
            broadcast.Content = broadcast.Content.Replace("$victimrole", ev.Player.Role.Translation());

            foreach (Player player in Player.Get(Team.SCP))
                player.Broadcast(broadcast);
        }

        private void OnVerified(VerifiedEventArgs ev)
        {
            ev.Player.Broadcast(plugin.Config.JoinBroadcast);
        }

        private void ShowScpTerminationBroadcast(DyingEventArgs ev)
        {
            Broadcast broadcast;
            if (ev.Killer == null)
            {
                broadcast = plugin.Config.ScpTerminationConfig.ScpSuicideBroadcast;
                broadcast.Content = broadcast.Content.Replace("$scptype", ev.Target.Role.Translation())
                    .Replace("$scpusername", ev.Target.DisplayNickname ?? ev.Target.Nickname);

                Map.Broadcast(broadcast);
                return;
            }

            broadcast = plugin.Config.ScpTerminationConfig.ScpTerminationBroadcast;
            broadcast.Content = broadcast.Content.Replace("$scptype", ev.Target.Role.Translation())
                .Replace("$killerrolecolor", ev.Killer.RoleColor.ToHex())
                .Replace("$killerteam", ev.Killer.Role.Translation());

            Map.Broadcast(broadcast);
        }

        private IEnumerator<float> RunSpawnProtectionHint(Player player)
        {
            for (int i = (int)CharacterClassManager.SProtectedDuration; i > 0; i--)
            {
                player.ShowHint(plugin.Config.SpawnProtectionHintConfig.Content.Replace("$time", i.ToString()));
                yield return Timing.WaitForSeconds(0.9f);
            }
        }
    }
}
// -----------------------------------------------------------------------
// <copyright file="Config.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace BroadcastUtility
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using BroadcastUtility.Configs;
    using Exiled.API.Enums;
    using Exiled.API.Features;
    using Exiled.API.Interfaces;

    /// <inheritdoc />
    public class Config : IConfig
    {
        /// <inheritdoc />
        public bool IsEnabled { get; set; } = true;

        /// <summary>
        /// Gets or sets all roles and their respective translations.
        /// </summary>
        [Description("All roles and their respective translations.")]
        public Dictionary<RoleType, string> TranslatedRoles { get; set; } = new Dictionary<RoleType, string>
        {
            { RoleType.ClassD, "Class-D Personnel" },
            { RoleType.Scientist, "Scientist" },
            { RoleType.FacilityGuard, "Facility Guard" },
            { RoleType.NtfPrivate, "NTF Private" },
            { RoleType.NtfSergeant, "NTF Sergeant" },
            { RoleType.NtfSpecialist, "NTF Specialist" },
            { RoleType.NtfCaptain, "NTF Captain" },
            { RoleType.ChaosRifleman, "Chaos Rifleman" },
            { RoleType.ChaosConscript, "Chaos Conscript" },
            { RoleType.ChaosRepressor, "Chaos Repressor" },
            { RoleType.ChaosMarauder, "Chaos Marauder" },
            { RoleType.Tutorial, "Tutorial" },
            { RoleType.Scp049, "Scp049" },
            { RoleType.Scp079, "Scp079" },
            { RoleType.Scp173, "Scp173" },
            { RoleType.Scp93953, "Scp939-53" },
            { RoleType.Scp93989, "Scp939-89" },
            { RoleType.Scp106, "Scp106" },
            { RoleType.Scp0492, "Scp049-2" },
            { RoleType.Scp096, "Scp096" },
        };

        /// <summary>
        /// Gets or sets sides and the respective broadcasts to play when there is only one player remaining.
        /// </summary>
        public Dictionary<Side, Broadcast> LastPersonnelBroadcasts { get; set; } = new Dictionary<Side, Broadcast>
        {
            { Side.ChaosInsurgency, new Broadcast("$last is the last remaining member of the Chaos Insurgency!") },
            { Side.Mtf, new Broadcast("$last is the last remaining member of the MTF!") },
            { Side.Scp, new Broadcast("$last is the last remaining SCP!") },
        };

        /// <summary>
        /// Gets or sets the broadcast to send to chaos insurgency when all class d personnel have been killed.
        /// </summary>
        [Description("The broadcast to send to chaos insurgency when all class d personnel have been killed.")]
        public Broadcast AllClassdHaveBeenKilledBroadcast { get; set; } = new Broadcast("All ClassD personnel have been eliminated!");

        /// <summary>
        /// Gets or sets the broadcast to send to all scp subjects once a player enters the femur breaker.
        /// </summary>
        [Description("The broadcast to send to all scp subjects once a player enters the femur breaker. Available Variables: $victimrole")]
        public Broadcast FemurBreakerEnteredBroadcast { get; set; } = new Broadcast("A $victimrole has entered the femur breaker!");

        /// <summary>
        /// Gets or sets the broadcast to show to a player when they join.
        /// </summary>
        [Description("The broadcast to show to a player when they join.")]
        public Broadcast JoinBroadcast { get; set; } = new Broadcast("Welcome to the server!");

        /// <summary>
        /// Gets or sets the broadcast to show when the round ends.
        /// </summary>
        [Description("The broadcast to show when the round ends. Available Variables: $classdescape, $sciescape, $mtfspawn, $scpkills")]
        public Broadcast RoundEndedBroadcast { get; set; } = new Broadcast("Escaped ClassDs: $classdescape\nEscaped Scientists: $sciescape\nMTF Spawned: $mtfspawn\nScp Kills: $scpkills");

        /// <summary>
        /// Gets or sets the broadcast to play to scp subjects when they spawn in.
        /// </summary>
        [Description("The broadcast to play to scp subjects when they spawn in.")]
        public Broadcast ScpSpawnBroadcast { get; set; } = new Broadcast("Current Scps:\n<color=red>$scplist</color>");

        /// <summary>
        /// Gets or sets all auto-broadcast related configs.
        /// </summary>
        public AutoBroadcastConfig AutoBroadcastConfig { get; set; } = new AutoBroadcastConfig();

        /// <summary>
        /// Gets or sets all decontamination related configs.
        /// </summary>
        public DecontaminationConfig DecontaminationConfig { get; set; } = new DecontaminationConfig();

        /// <summary>
        /// Gets or sets all generator related configs.
        /// </summary>
        public GeneratorsConfig GeneratorsConfig { get; set; } = new GeneratorsConfig();

        /// <summary>
        /// Gets or sets all scplist related configs.
        /// </summary>
        public ScpListConfig ScpListConfig { get; set; } = new ScpListConfig();

        /// <summary>
        /// Gets or sets all scp termination related configs.
        /// </summary>
        public ScpTerminationConfig ScpTerminationConfig { get; set; } = new ScpTerminationConfig();

        /// <summary>
        /// Gets or sets all configs related to the spawn protection hint.
        /// </summary>
        public SpawnProtectionHintConfig SpawnProtectionHintConfig { get; set; } = new SpawnProtectionHintConfig();

        /// <summary>
        /// Gets or sets all team respawn related configs.
        /// </summary>
        public TeamRespawnConfig TeamRespawnConfig { get; set; } = new TeamRespawnConfig();

        /// <summary>
        /// Gets or sets all warhead related configs.
        /// </summary>
        public WarheadConfig WarheadConfig { get; set; } = new WarheadConfig();
    }
}
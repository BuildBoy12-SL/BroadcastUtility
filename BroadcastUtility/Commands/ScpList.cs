// -----------------------------------------------------------------------
// <copyright file="ScpList.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace BroadcastUtility.Commands
{
    using System;
    using System.Text;
    using BroadcastUtility.API;
    using CommandSystem;
    using Exiled.API.Features;
    using NorthwoodLib.Pools;

    /// <inheritdoc />
    [CommandHandler(typeof(ClientCommandHandler))]
    public class ScpList : ICommand
    {
        private readonly Plugin plugin;

        /// <summary>
        /// Initializes a new instance of the <see cref="ScpList"/> class.
        /// </summary>
        public ScpList()
        {
            plugin = Plugin.Instance;
            Command = plugin.Config.ScpListConfig.CommandName;
            Aliases = plugin.Config.ScpListConfig.CommandAliases;
            Description = plugin.Config.ScpListConfig.CommandDescription;
        }

        /// <inheritdoc />
        public string Command { get; }

        /// <inheritdoc />
        public string[] Aliases { get; }

        /// <inheritdoc />
        public string Description { get; }

        /// <inheritdoc />
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Player player = Player.Get(sender);
            if (player == null)
            {
                response = plugin.Config.ScpListConfig.InGameOnlyResponse;
                return false;
            }

            if (!player.IsScp)
            {
                response = plugin.Config.ScpListConfig.ScpOnlyResponse;
                return false;
            }

            StringBuilder stringBuilder = StringBuilderPool.Shared.Rent().AppendLine();
            foreach (Player scp in Player.Get(Team.SCP))
                stringBuilder.Append(scp.Role.Translation()).Append(" - ").AppendLine(scp.DisplayNickname ?? scp.Nickname);

            response = StringBuilderPool.Shared.ToStringReturn(stringBuilder).TrimEnd();
            return true;
        }
    }
}
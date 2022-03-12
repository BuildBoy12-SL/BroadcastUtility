// -----------------------------------------------------------------------
// <copyright file="ScpList.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace BroadcastUtility.Commands
{
    using System;
    using System.ComponentModel;
    using System.Text;
    using BroadcastUtility.API;
    using CommandSystem;
    using Exiled.API.Features;
    using NorthwoodLib.Pools;

    /// <inheritdoc />
    public class ScpList : ICommand
    {
        /// <inheritdoc />
        public string Command { get; set; } = "scplist";

        /// <inheritdoc />
        public string[] Aliases { get; set; } = { "listscps" };

        /// <inheritdoc />
        public string Description { get; set; } = "Lists all SCP teammates.";

        /// <summary>
        /// Gets or sets the response to send when the command is executed by the server.
        /// </summary>
        [Description("The response to send when the command is executed by the server.")]
        public string InGameOnlyResponse { get; set; } = "This command may only be used at the game level.";

        /// <summary>
        /// Gets or sets the response to send when the command is executed by a human player.
        /// </summary>
        [Description("The response to send when the command is executed by a human player.")]
        public string ScpOnlyResponse { get; set; } = "You must be an Scp to use this command.";

        /// <inheritdoc />
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Player player = Player.Get(sender);
            if (player == null)
            {
                response = InGameOnlyResponse;
                return false;
            }

            if (!player.IsScp)
            {
                response = ScpOnlyResponse;
                return false;
            }

            StringBuilder stringBuilder = StringBuilderPool.Shared.Rent().AppendLine();
            foreach (Player scp in Player.Get(Team.SCP))
                stringBuilder.Append(scp.Role.Type.Translation()).Append(" - ").AppendLine(scp.DisplayNickname ?? scp.Nickname);

            response = StringBuilderPool.Shared.ToStringReturn(stringBuilder).TrimEnd();
            return true;
        }
    }
}
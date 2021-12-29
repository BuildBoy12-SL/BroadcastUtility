// -----------------------------------------------------------------------
// <copyright file="Methods.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace BroadcastUtility
{
    using System.Text;
    using BroadcastUtility.API;
    using Exiled.API.Features;
    using NorthwoodLib.Pools;

    /// <summary>
    /// Various helpful methods.
    /// </summary>
    public static class Methods
    {
        /// <summary>
        /// Generates a formatted list of scp roles and the players controlling them.
        /// </summary>
        /// <returns>A formatted list of scps and their players.</returns>
        public static string GenerateScpList()
        {
            StringBuilder stringBuilder = StringBuilderPool.Shared.Rent();
            foreach (Player scp in Player.Get(Team.SCP))
                stringBuilder.Append(scp.Role.Translation()).Append(" - ").AppendLine(scp.DisplayNickname ?? scp.Nickname);

            return StringBuilderPool.Shared.ToStringReturn(stringBuilder).TrimEnd();
        }
    }
}
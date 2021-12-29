// -----------------------------------------------------------------------
// <copyright file="Extensions.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace BroadcastUtility.API
{
    using System;

    /// <summary>
    /// Various helpful extension methods.
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Returns the configured name of a role.
        /// </summary>
        /// <param name="roleType">The role to translate.</param>
        /// <returns>The configured translation in <see cref="Config.TranslatedRoles"/>, or the <see cref="Enum.ToString()"/> representation if one is not found.</returns>
        public static string Translation(this RoleType roleType)
        {
            if (Plugin.Instance.Config.TranslatedRoles.TryGetValue(roleType, out string translation))
                return translation;

            return roleType.ToString();
        }
    }
}
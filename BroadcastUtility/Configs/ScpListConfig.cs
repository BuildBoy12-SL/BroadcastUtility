// -----------------------------------------------------------------------
// <copyright file="ScpListConfig.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace BroadcastUtility.Configs
{
    using System.ComponentModel;

    /// <summary>
    /// Handles configuration in relation to the scplist command and broadcasts.
    /// </summary>
    public class ScpListConfig
    {
        /// <summary>
        /// Gets or sets the name of the command.
        /// </summary>
        [Description("The name of the command.")]
        public string CommandName { get; set; } = "scplist";

        /// <summary>
        /// Gets or sets a collection of aliases that can be used to execute the command.
        /// </summary>
        [Description("A collection of aliases that can be used to execute the command.")]
        public string[] CommandAliases { get; set; } = { "listscps" };

        /// <summary>
        /// Gets or sets the description of the command.
        /// </summary>
        [Description("The description of the command.")]
        public string CommandDescription { get; set; } = "Lists all SCP teammates.";

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
    }
}
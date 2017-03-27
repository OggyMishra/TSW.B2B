// ***********************************************************************
// <copyright file="LogInfo.cs" company="Verisk">
//     Copyright © Verisk, All Rights Reserved.
// </copyright>
// <summary>LogInfo class</summary>
// ***********************************************************************
namespace TSW.B2B.Common
{
    using System;

    /// <summary>
    /// Log Info class
    /// </summary>
    public class LogInfo
    {
        /// <summary>
        /// Gets or sets action that is being logged
        /// </summary>
        /// <value>
        /// The action.
        /// </value>
        public string Action { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets type exception that caused log message
        /// </summary>
        /// <value>
        /// The exception.
        /// </value>
        public Exception Exception { get; set; }

        /// <summary>
        /// Gets or sets module to which action belongs
        /// </summary>
        /// <value>
        /// The module.
        /// </value>
        public string Module { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets properties associated with log message
        /// </summary>
        /// <value>
        /// The properties.
        /// </value>
        public dynamic Properties { get; set; }

        /// <summary>
        /// Gets or sets time stamp when issue is logged
        /// </summary>
        /// <value>
        /// The timestamp.
        /// </value>
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Gets or sets id of user who is associated with log message
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public string UserId { get; set; } = string.Empty;
    }
}

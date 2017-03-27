// ***********************************************************************
// <copyright file="LogInfoExtended.cs" company="Verisk">
//     Copyright © Verisk, All Rights Reserved.
// </copyright>
// <summary>LogInfoExtended class</summary>
// ***********************************************************************
namespace TSW.B2B.Common
{
    /// <summary>
    /// LogInfoExtended class.
    /// </summary>
    /// <seealso cref="TSW.B2B.Common.LogInfo" />
    public class LogInfoExtended : LogInfo
    {
        /// <summary>
        /// Gets or sets the name of the company.
        /// </summary>
        /// <value>
        /// The name of the company.
        /// </value>
        public string CompanyName { get; set; }

        /// <summary>
        /// Gets or sets the function.
        /// </summary>
        /// <value>
        /// The function.
        /// </value>
        public string Function { get; set; }

        /// <summary>
        /// Gets or sets the input.
        /// </summary>
        /// <value>
        /// The input.
        /// </value>
        public string Input { get; set; }

        /// <summary>
        /// Gets or sets reads customer tenant id from request context
        /// </summary>
        /// <value>
        /// The name of the machine.
        /// </value>
        public string MachineName { get; set; }

        /// <summary>
        /// Gets or sets the output.
        /// </summary>
        /// <value>
        /// The output.
        /// </value>
        public string Output { get; set; }

        /// <summary>
        /// Gets or sets the parent company.
        /// </summary>
        /// <value>
        /// The parent company.
        /// </value>
        public string ParentCompany { get; set; }

        /// <summary>
        /// Gets or sets the request identifier.
        /// </summary>
        /// <value>
        /// The request identifier.
        /// </value>
        public string RequestId { get; set; }

        /// <summary>
        /// Gets or sets the role identifier.
        /// </summary>
        /// <value>
        /// The role identifier.
        /// </value>
        public string RoleId { get; set; }

        /// <summary>
        /// Gets or sets the name of the role.
        /// </summary>
        /// <value>
        /// The name of the role.
        /// </value>
        public string RoleName { get; set; }

        /// <summary>
        /// Gets or sets the tenant identifier.
        /// </summary>
        /// <value>
        /// The tenant identifier.
        /// </value>
        public string TenantId { get; set; }

        /// <summary>
        /// Gets or sets the ticket.
        /// </summary>
        /// <value>
        /// The ticket.
        /// </value>
        public string Ticket { get; set; }

        /// <summary>
        /// Gets or sets the time taken.
        /// </summary>
        /// <value>
        /// The time taken.
        /// </value>
        public long TimeTaken { get; set; }
    }
}

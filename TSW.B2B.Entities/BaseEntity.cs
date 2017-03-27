using System;

namespace TSW.B2B.Entities
{
    /// <summary>
    /// Base Entity Class
    /// </summary>
    public class BaseEntity
    {
        /// <summary>
        ///  Gets or sets ID
        /// </summary>
        /// <value>Id Property</value>
        public string Id { get; set; }
        /// <summary>
        /// Who crated the entity
        /// </summary>
        /// <value>Created by Property</value>
        public string CreatedBy { get; set; }
        /// <summary>
        /// When the entity created
        /// </summary>
        /// <value>created date Property</value>
        public DateTime CreatedDate { get; set; }
        /// <summary>
        /// Who modified the entity
        /// </summary>
        /// <value>Modified by Property</value>
        public string ModifiedBy { get; set; }
        /// <summary>
        /// When the entity is modified
        /// </summary>
        /// <value>Modified date Property</value>
        public DateTime ModifiedDate { get; set; }
    }
}
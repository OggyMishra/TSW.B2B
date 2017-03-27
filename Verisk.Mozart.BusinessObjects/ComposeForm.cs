// ***********************************************************************
// <copyright file="ComposeForm.cs" company="Verisk">
//     Copyright © Verisk, All Rights Reserved.
// </copyright>
// <summary>Compose form class</summary>
// ***********************************************************************
namespace Verisk.Mozart.BusinessObjects
{
    using System;
    using System.Collections.Generic;
    using MongoDB.Bson;
    
    /// <summary>
    /// This class will hold the business object for creating a compose form.
    /// </summary>
    public class ComposeForm
    {
        /// <summary>
        /// Bson Id of the comment
        /// </summary>
        /// <value>Object id Property</value>
        public ObjectId Id { get; set; }

        /// <summary>
        /// Id of the document
        /// </summary>
        /// <value>Document id Property</value>
        public string DocumentId { get; set; }

        /// <summary>
        /// Compose Form Id
        /// </summary>
        /// <value>Compose form id Property</value>
        public Guid ComposeFormId { get; set; }

        /// <summary>
        /// Compose form number
        /// </summary>
        /// <value>Compose form number Property</value>
        public string ComposeFormNumber { get; set; }

        /// <summary>
        /// If selected returns true else false
        /// </summary>
        /// <value>single form format Property</value>
        public bool IsOneColumnFormFormat { get; set; }

        /// <summary>
        /// If selected returns true else false
        /// </summary>
        /// <value>single form format Property</value>
        public bool IsTwoColumnFormFormat { get; set; }
        
        /// <summary>
        /// policy number of the form
        /// </summary>
        /// <value>policy number form Property</value>
        public bool IsPolicyNumberChecked { get; set; }

        /// <summary>
        /// Endorsement line of the form
        /// </summary>
        /// <value>Endorsement line form Property</value>
        public bool IsEndorsementLineChecked { get; set; }

        /// <summary>
        /// List General LOB
        /// </summary>
        public IList<GeneralLob> LOBList { get; set; }

        /// <summary>
        /// List of Coveraga part types
        /// </summary>
        public IList<GeneralCoveragePart> Coverages { get; set; }

        /// <summary>
        /// Copy right year line of the form
        /// </summary>
        /// <value>Int </value>
        public int CopyRightYear { get; set; }

        /// <summary>
        /// List of Coveraga part types
        /// </summary>
        public IList<Copyright> CopyrightLineItems { get; set; }
    }
}

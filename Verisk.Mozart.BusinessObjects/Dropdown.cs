// ***********************************************************************
// <copyright file="Dropdown.cs" company="Verisk">
//     Copyright © Verisk, All Rights Reserved.
// </copyright>
// <summary>Dropdown class</summary>
// ***********************************************************************
namespace Verisk.Mozart.BusinessObjects
{
    using MongoDB.Bson;
    /// <summary>
    /// DropDown Poco Class
    /// </summary>
    public class Dropdown
    {
        /// <summary>
        /// Mongo Bson Object Id
        /// </summary>
        /// <value> ObjectId Bson </value>
        public ObjectId ObjId { get; set; }
        /// <summary>
        /// DropdownId Id
        /// </summary>
        /// <value> DropdownId Int </value>
        public int DropDownId { get; set; }
        /// <summary>
        /// Dropdown Value
        /// </summary>
        /// <value> DropdownValue string </value>
        public string DropDownValue { get; set; }
    }
}

// ----------------------------------------------------------------------------
// <copyright file="CustomerDto.cs" company="SOGETI Spain">
//     Copyright © 2017 SOGETI Spain. All rights reserved.
//     Powered by Óscar Fernández González a.k.a. Osc@rNET.
// </copyright>
// ----------------------------------------------------------------------------
namespace SogetiSpain.TradingManagement.Models
{
    using System.Runtime.Serialization;

    /// <summary>
    /// Represents the data transfer object of customer.
    /// </summary>
    [DataContract]
    public class CustomerDto
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [DataMember]
        public long Id { get; set; }

        /// <summary>
        /// Gets or sets the full name.
        /// </summary>
        /// <value>
        /// The full name.
        /// </value>
        [DataMember]
        public string FullName { get; set; }
    }
}
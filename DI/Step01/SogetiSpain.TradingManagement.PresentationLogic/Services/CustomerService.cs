// ----------------------------------------------------------------------------
// <copyright file="CustomerService.cs" company="SOGETI Spain">
//     Copyright © 2017 SOGETI Spain. All rights reserved.
//     Powered by Óscar Fernández González a.k.a. Osc@rNET.
// </copyright>
// ----------------------------------------------------------------------------
namespace SogetiSpain.TradingManagement.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using SogetiSpain.TradingManagement.Models;

    /// <summary>
    /// Represents the customer service.
    /// </summary>
    public class CustomerService
    {
        /// <summary>
        /// Defines the dummy customer list.
        /// </summary>
        private readonly List<CustomerDto> _dummyCustomerList = new[]
        {
            new CustomerDto() { Id = 1, FullName = "Avelino López García" },
            new CustomerDto() { Id = 2, FullName = "Yolanda Sánchez Sánchez" },
            new CustomerDto() { Id = 3, FullName = "Pedro Chaves Ferreira" },
            new CustomerDto() { Id = 4, FullName = "Modesto Estrada" },
            new CustomerDto() { Id = 5, FullName = "Luis Alverca" },
            new CustomerDto() { Id = 6, FullName = "Almudena Benito" },
            new CustomerDto() { Id = 7, FullName = "Fernando Caro" },
            new CustomerDto() { Id = 8, FullName = "Alfredo Fuentes Espinos" },
            new CustomerDto() { Id = 9, FullName = "Vanesa García" },
            new CustomerDto() { Id = 10, FullName = "Franciso Javier Castrejón" },
        }
        .ToList();

        /// <summary>
        /// Gets a customer by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// The retrieved customer.
        /// </returns>
        public CustomerDto GetById(long id)
        {
            // Here would be the corresponding WCF service call,
            // this is a fake desmotration.
            return _dummyCustomerList.FirstOrDefault(customer => (customer.Id == id));
        }

        /// <summary>
        /// Gets a customer list.
        /// </summary>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>
        /// The retrieved customer list.
        /// </returns>
        public IEnumerable<CustomerDto> GetList(int pageIndex, int pageSize)
        {
            // Here would be the corresponding WCF service call,
            // this is a fake desmotration.
            return _dummyCustomerList.OrderBy(customer => customer.FullName).ToList();
        }
    }
}
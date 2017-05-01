// ----------------------------------------------------------------------------
// <copyright file="UIModule.cs" company="SOGETI Spain">
//     Copyright © 2017 SOGETI Spain. All rights reserved.
//     Powered by Óscar Fernández González a.k.a. Osc@rNET.
// </copyright>
// ----------------------------------------------------------------------------
namespace SogetiSpain.TradingManagement.UI
{
    using System;
    using Microsoft.Practices.Unity;
    using Prism.Modularity;
    using SogetiSpain.TradingManagement.Views;

    /// <summary>
    /// Represents the UI module.
    /// </summary>
    public sealed class UIModule : IModule
    {
        /// <summary>
        /// Defines the container.
        /// </summary>
        private readonly IUnityContainer _container;

        /// <summary>
        /// Initializes a new instance of the <see cref="UIModule"/> class.
        /// </summary>
        /// <param name="container">The container.</param>
        public UIModule(IUnityContainer container)
        {
            _container = container ?? throw new ArgumentNullException(nameof(container));
        }

        /// <summary>
        /// Notifies the module that it has be initialized.
        /// </summary>
        public void Initialize()
        {
            _container.RegisterType<object, CustomerDetailsView>(typeof(CustomerDetailsView).Name);
            _container.RegisterType<object, CustomerListView>(typeof(CustomerListView).Name);
            _container.RegisterType<object, MainWindow>(typeof(MainWindow).Name);
            _container.RegisterType<object, ProductDetailsView>(typeof(ProductDetailsView).Name);
            _container.RegisterType<object, ProductListView>(typeof(ProductListView).Name);
            _container.RegisterType<object, ProviderDetailsView>(typeof(ProviderDetailsView).Name);
            _container.RegisterType<object, ProviderListView>(typeof(ProviderListView).Name);
            _container.RegisterType<object, PurchaseOrderDetailsView>(typeof(PurchaseOrderDetailsView).Name);
            _container.RegisterType<object, PurchaseOrderListView>(typeof(PurchaseOrderListView).Name);
            _container.RegisterType<object, SaleOrderDetailsView>(typeof(SaleOrderDetailsView).Name);
            _container.RegisterType<object, SaleOrderListView>(typeof(SaleOrderListView).Name);
        }
    }
}
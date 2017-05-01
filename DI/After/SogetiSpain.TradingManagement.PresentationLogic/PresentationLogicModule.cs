// ----------------------------------------------------------------------------
// <copyright file="PresentationLogicModule.cs" company="SOGETI Spain">
//     Copyright © 2017 SOGETI Spain. All rights reserved.
//     Powered by Óscar Fernández González a.k.a. Osc@rNET.
// </copyright>
// ----------------------------------------------------------------------------
namespace SogetiSpain.TradingManagement.PresentationLogic
{
    using System;
    using Microsoft.Practices.Unity;
    using Prism.Modularity;
    using SogetiSpain.TradingManagement.ViewModels;

    /// <summary>
    /// Represents the presentation logic module.
    /// </summary>
    public sealed class PresentationLogicModule : IModule
    {
        /// <summary>
        /// Defines the container.
        /// </summary>
        private readonly IUnityContainer _container;

        /// <summary>
        /// Initializes a new instance of the <see cref="PresentationLogicModule"/> class.
        /// </summary>
        /// <param name="container">The container.</param>
        public PresentationLogicModule(IUnityContainer container)
        {
            _container = container ?? throw new ArgumentNullException(nameof(container));
        }

        /// <summary>
        /// Notifies the module that it has be initialized.
        /// </summary>
        public void Initialize()
        {
            _container.RegisterType<ICustomerDetailsViewModel, CustomerDetailsViewModel>();
            _container.RegisterType<ICustomerListViewModel, CustomerListViewModel>();
            _container.RegisterType<IMainWindowViewModel, MainWindowViewModel>();
            _container.RegisterType<IProductDetailsViewModel, ProductDetailsViewModel>();
            _container.RegisterType<IProductListViewModel, ProductListViewModel>();
            _container.RegisterType<IProviderDetailsViewModel, ProviderDetailsViewModel>();
            _container.RegisterType<IProviderListViewModel, ProviderListViewModel>();
            _container.RegisterType<IPurchaseOrderDetailsViewModel, PurchaseOrderDetailsViewModel>();
            _container.RegisterType<IPurchaseOrderListViewModel, PurchaseOrderListViewModel>();
            _container.RegisterType<ISaleOrderDetailsViewModel, SaleOrderDetailsViewModel>();
            _container.RegisterType<ISaleOrderListViewModel, SaleOrderListViewModel>();
        }
    }
}
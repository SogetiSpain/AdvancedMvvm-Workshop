﻿// ----------------------------------------------------------------------------
// <copyright file="PurchaseOrderDetailsView.xaml.cs" company="SOGETI Spain">
//     Copyright © 2017 SOGETI Spain. All rights reserved.
//     Powered by Óscar Fernández González a.k.a. Osc@rNET.
// </copyright>
// ----------------------------------------------------------------------------
namespace SogetiSpain.TradingManagement.Views
{
    using System.Windows.Controls;
    using SogetiSpain.TradingManagement.ViewModels;

    /// <summary>
    /// Interaction logic for PurchaseOrderDetailsView.xaml.
    /// </summary>
    internal partial class PurchaseOrderDetailsView : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PurchaseOrderDetailsView"/> class.
        /// </summary>
        public PurchaseOrderDetailsView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PurchaseOrderDetailsView"/> class.
        /// </summary>
        /// <param name="viewModel">The view model.</param>
        public PurchaseOrderDetailsView(IPurchaseOrderDetailsViewModel viewModel)
            : this()
        {
            DataContext = viewModel;
        }
    }
}
﻿// ----------------------------------------------------------------------------
// <copyright file="SaleOrderDetailsView.xaml.cs" company="SOGETI Spain">
//     Copyright © 2017 SOGETI Spain. All rights reserved.
//     Powered by Óscar Fernández González a.k.a. Osc@rNET.
// </copyright>
// ----------------------------------------------------------------------------
namespace SogetiSpain.TradingManagement.Views
{
    using System.Windows.Controls;
    using SogetiSpain.TradingManagement.ViewModels;

    /// <summary>
    /// Interaction logic for SaleOrderDetailsView.xaml.
    /// </summary>
    internal partial class SaleOrderDetailsView : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SaleOrderDetailsView"/> class.
        /// </summary>
        public SaleOrderDetailsView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SaleOrderDetailsView"/> class.
        /// </summary>
        /// <param name="viewModel">The view model.</param>
        public SaleOrderDetailsView(ISaleOrderDetailsViewModel viewModel)
            : this()
        {
            DataContext = viewModel;
        }
    }
}
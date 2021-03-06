﻿// ----------------------------------------------------------------------------
// <copyright file="CustomerDetailsView.xaml.cs" company="SOGETI Spain">
//     Copyright © 2017 SOGETI Spain. All rights reserved.
//     Powered by Óscar Fernández González a.k.a. Osc@rNET.
// </copyright>
// ----------------------------------------------------------------------------
namespace SogetiSpain.TradingManagement.Views
{
    using System.Windows.Controls;
    using SogetiSpain.TradingManagement.ViewModels;

    /// <summary>
    /// Interaction logic for CustomerDetailsView.xaml.
    /// </summary>
    internal partial class CustomerDetailsView : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerDetailsView"/> class.
        /// </summary>
        public CustomerDetailsView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerDetailsView"/> class.
        /// </summary>
        /// <param name="viewModel">The view model.</param>
        public CustomerDetailsView(ICustomerDetailsViewModel viewModel)
            : this()
        {
            DataContext = viewModel;
        }
    }
}
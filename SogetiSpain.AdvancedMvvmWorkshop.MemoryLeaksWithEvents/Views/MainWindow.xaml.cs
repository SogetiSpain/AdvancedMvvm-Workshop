// ----------------------------------------------------------------------------
// <copyright file="MainWindow.xaml.cs" company="SOGETI Spain">
//     Copyright © 2017 SOGETI Spain. All rights reserved.
//     Powered by Óscar Fernández González a.k.a. Osc@rNET.
// </copyright>
// ----------------------------------------------------------------------------
namespace SogetiSpain.AdvancedMvvmWorkshop.MemoryLeaksWithEvents.Views
{
    using System;
    using System.Windows;
    using SogetiSpain.AdvancedMvvmWorkshop.MemoryLeaksWithEvents.ViewModels;

    /// <summary>
    /// Interaction logic for MainWindow.xaml.
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        /// <param name="viewModel">The view model.</param>
        public MainWindow(MainWindowViewModel viewModel)
            : this()
        {
            DataContext = viewModel ?? throw new ArgumentNullException(nameof(viewModel));
        }
    }
}
// ----------------------------------------------------------------------------
// <copyright file="App.xaml.cs" company="SOGETI Spain">
//     Copyright © 2017 SOGETI Spain. All rights reserved.
//     Powered by Óscar Fernández González a.k.a. Osc@rNET.
// </copyright>
// ----------------------------------------------------------------------------
namespace SogetiSpain.AdvancedMvvmWorkshop.MemoryLeaksWithEvents
{
    using System.Windows;
    using SogetiSpain.AdvancedMvvmWorkshop.MemoryLeaksWithEvents.ViewModels;
    using SogetiSpain.AdvancedMvvmWorkshop.MemoryLeaksWithEvents.Views;

    /// <summary>
    /// Interaction logic for App.xaml.
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Generates the <see cref="E:System.Windows.Application.Startup" /> event.
        /// </summary>
        /// <param name="e"><see cref="T:System.Windows.StartupEventArgs" /> object containing the event data.</param>
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            ShutdownMode = ShutdownMode.OnMainWindowClose;

            MainWindow = new MainWindow(new MainWindowViewModel());
            MainWindow.Show();
        }
    }
}
// ----------------------------------------------------------------------------
// <copyright file="Bootstrapper.cs" company="SOGETI Spain">
//     Copyright © 2017 SOGETI Spain. All rights reserved.
//     Powered by Óscar Fernández González a.k.a. Osc@rNET.
// </copyright>
// ----------------------------------------------------------------------------
namespace SogetiSpain.TradingManagement
{
    using System.Linq;
    using System.Reflection;
    using System.Windows;
    using Microsoft.Practices.Unity;
    using Prism.Modularity;
    using Prism.Unity;

    /// <summary>
    /// Represents the bootstrapper.
    /// </summary>
    internal sealed class Bootstrapper : UnityBootstrapper
    {
        /// <summary>
        /// Defines the value determining if the modules were initialized.
        /// </summary>
        private volatile bool _wereModulesInitialized;

        /// <summary>
        /// Creates the <see cref="T:Prism.Modularity.IModuleCatalog" /> used by Prism.
        /// </summary>
        /// <returns>
        /// The created module catalog.
        /// </returns>
        protected override IModuleCatalog CreateModuleCatalog()
        {
            // Alternative location of the modules.
            var assembly = Assembly.GetExecutingAssembly();
            var attributes = assembly.GetCustomAttributes(true);
            var configurationAttribute = attributes.OfType<AssemblyConfigurationAttribute>().FirstOrDefault();
            var path = @"..\..\..\SogetiSpain.TradingManagement.Modules\" + configurationAttribute.Configuration;

            path = ".";

            return new DirectoryModuleCatalog() { ModulePath = path };
        }

        /// <summary>
        /// Creates the shell or main window of the application.
        /// </summary>
        /// <returns>
        /// The shell of the application.
        /// </returns>
        /// <remarks>
        /// If the returned instance is a <see cref="T:System.Windows.DependencyObject" />, the
        /// <see cref="T:Prism.Bootstrapper" /> will attach the default <see cref="T:Prism.Regions.IRegionManager" /> of
        /// the application in its <see cref="F:Prism.Regions.RegionManager.RegionManagerProperty" /> attached property
        /// in order to be able to add regions by using the <see cref="F:Prism.Regions.RegionManager.RegionNameProperty" />
        /// attached property from XAML.
        /// </remarks>
        protected override DependencyObject CreateShell()
        {
            return !_wereModulesInitialized ? null : (DependencyObject)Container.Resolve<object>("MainWindow");
        }

        /// <summary>
        /// Initializes the modules. May be overwritten in a derived class to use a custom Modules Catalog
        /// </summary>
        protected override void InitializeModules()
        {
            base.InitializeModules();

            _wereModulesInitialized = true;
            InitializeShell();
        }

        /// <summary>
        /// Initializes the shell.
        /// </summary>
        protected override void InitializeShell()
        {
            if (_wereModulesInitialized)
            {
                Shell = CreateShell();
                ((Window)Shell).Show();
            }
        }
    }
}

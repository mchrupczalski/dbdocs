using DryIoc;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace dbdocs
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public IContainer AppContainer { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            this.AppContainer = StartUp.Bootstrapper.ConfigureContainer();

            AppContainer.Resolve<MainWindow>().Show();
        }
    }
}

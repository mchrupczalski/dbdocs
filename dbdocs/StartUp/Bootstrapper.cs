using dbdocs.Interfaces;
using dbdocs.Models;
using dbdocs.Serializers;
using dbdocs.Services;
using dbdocs.ViewModels;
using dbdocs.Views;
using DryIoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbdocs.StartUp
{
    public static class Bootstrapper
    {
        internal static IContainer ConfigureContainer()
        {
            var container = new Container();


            #region Models

            container.Register<IConfigModel, ConfigModel>(Reuse.Singleton);

            #endregion

            #region ViewModels

            container.Register<IShellViewModel, ShellViewModel>(
                Made.Of(() => new ShellViewModel(Arg.Of<IShellViewNavigationService>())));

            container.Register<IConfigViewModel, ConfigViewModel>(
                Made.Of(() => new ConfigViewModel(Arg.Of<IJsonSerializer>(), Arg.Of<IConfigModel>())));

            #endregion

            #region Views

            container.Register<IShellView, ShellView>();
            container.Register<IConfigView, ConfigView>();

            #endregion

            #region Serializers

            container.Register<IJsonSerializer, JsonSerializer>();
            container.Register<IYamlSerializer, YamlSerializer>();

            #endregion

            #region Services

            container.Register<IShellViewNavigationService, ShellViewNavigationService>();

            #endregion

            container.Register<MainWindow>();

            return container;
        }
    }
}

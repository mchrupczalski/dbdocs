using dbdocs.Interfaces;
using System.Windows;
using System.Windows.Controls;

namespace dbdocs.Views
{
    /// <summary>
    /// Interaction logic for ConfigView.xaml
    /// </summary>
    public partial class ConfigView : UserControl, IConfigView, ITabView
    {
        private readonly IConfigViewModel _configViewModel;

        public ConfigView(IConfigViewModel configViewModel)
        {
            InitializeComponent();

            _configViewModel = configViewModel;
            DataContext = _configViewModel;

            Loaded += ConfigView_Loaded;
        }

        private void ConfigView_Loaded(object sender, RoutedEventArgs e)
        {
            _configViewModel.Load();
        }
    }
}

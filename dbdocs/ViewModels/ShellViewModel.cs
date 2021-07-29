using dbdocs.Interfaces;

namespace dbdocs.ViewModels
{
    public class ShellViewModel : IShellViewModel
    {
        private readonly IShellViewNavigationService _shellViewNavigationService;

        public ShellViewModel()
        {
        }

        public ShellViewModel(IShellViewNavigationService shellViewNavigationService)
        {
            _shellViewNavigationService = shellViewNavigationService;
        }

        public IConfigView ConfigView { get; }
        public IView CurrentView { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    }
}

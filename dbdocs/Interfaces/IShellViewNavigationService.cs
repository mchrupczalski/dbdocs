using System.Collections.Generic;

namespace dbdocs.Interfaces
{
    public interface IShellViewNavigationService
    {
        List<ITabView> TabViews { get; set; }
        int ActiveViewId { get; set; }

        void AddTabView(ITabView tabView);
    }
}
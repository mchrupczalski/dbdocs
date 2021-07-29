using dbdocs.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace dbdocs.Services
{
    public class ShellViewNavigationService : IShellViewNavigationService
    {
        public List<ITabView> TabViews { get; set; }
        public int ActiveViewId { get; set; }

        public ShellViewNavigationService() => this.TabViews = new List<ITabView>();

        public void AddTabView(ITabView tabView) => this.TabViews.Add(tabView);
    }
}

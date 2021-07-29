using System;
using System.Collections.Generic;
using System.Text;

namespace dbdocs.Interfaces
{
    public interface IView
    {
        public IViewModel ViewModel { get; set; }
    }
}

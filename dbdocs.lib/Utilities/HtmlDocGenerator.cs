using dbdocs.lib.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbdocs.lib.Utilities
{
    public class HtmlDocGenerator<T> where T : IServerModel
    {
        private readonly T _serverModel;

        public HtmlDocGenerator(T serverModel)
        {
            _serverModel = serverModel;
        }
    }
}

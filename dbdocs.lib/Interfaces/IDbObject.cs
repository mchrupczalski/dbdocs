using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbdocs.lib.Interfaces
{
    public interface IDbObject
    {
        public string Uid { get; set; }
        public string Name { get; set; }
    }
}

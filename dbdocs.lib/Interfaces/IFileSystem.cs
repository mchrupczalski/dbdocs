﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbdocs.lib.Interfaces
{
    public interface IFileSystem
    {
        public string ReadTextFile(string filePath);
    }
}

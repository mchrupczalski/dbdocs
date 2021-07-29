using dbdocs.Helpers;
using dbdocs.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace dbdocs.ViewModels
{
    public class ConfigViewModel : BindableBase, IConfigViewModel
    {
        private readonly IJsonSerializer _jsonSerializer;
        private string _testVal;

        public IConfigModel ConfigModel { get; }
        public string TestVal { get => _testVal; set { _testVal = value; base.OnPropertyChanged(); } }

        public ConfigViewModel()
        {
        }

        public ConfigViewModel(IJsonSerializer jsonSerializer, IConfigModel configModel)
        {
            _jsonSerializer = jsonSerializer;
            ConfigModel = configModel;
        }


        public void Load()
        {
            TestVal = "Testing Config View Model";
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Axxes.ToyCollector.Core.Helpers.ServiceLocation
{
    public class ServiceLocator
    {
        private static readonly ServiceLocator _instance = new ServiceLocator();
        public static ServiceLocator Instance => _instance;

        public TYPE Type { get; set; }
    }
}

using Autofac.EasyPropInject.Annotations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Autofac.EasyPropInject.Testing.mocks
{
    public interface IMock3
    {
        Mock4 Mock4ResolvedAsMainType { get; set; }

        string GetString();
    }
     

    public class Mock3 : IMock3
    {
        [FromAutofac(typeof(IMock4))]
        public Mock4 Mock4ResolvedAsMainType { get; set; }

        public string GetString()
        {
            return "Mock3:String";
        }
    }
}

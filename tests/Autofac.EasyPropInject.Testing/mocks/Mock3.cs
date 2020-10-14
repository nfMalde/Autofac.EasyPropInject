using Autofac.EasyPropInject.Annotations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Autofac.EasyPropInject.Testing.mocks
{
    public interface IMock3
    {

        string GetString();
    }
     

    public class Mock3 : IMock3
    {

        public string GetString()
        {
            return "Mock3:String";
        }
    }
}

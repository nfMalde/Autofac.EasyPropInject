using Autofac.EasyPropInject.Annotations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Autofac.EasyPropInject.Testing.mocks
{
    /// <summary>
    /// Mock1 Object
    /// </summary>
    public interface IMock1
    {
        IMock2 Mock2Property { get; set; }

        string getString();
    }

    /// <summary>
    /// Mock 1
    /// </summary>
    /// <seealso cref="Autofac.EasyPropInject.Testing.mocks.IMock1" />
    public class Mock1 : IMock1
    {

        [FromAutofac]
        public IMock2 Mock2Property { get; set; }

        public string getString()
        {
            return "System.String";
        }
    }
}

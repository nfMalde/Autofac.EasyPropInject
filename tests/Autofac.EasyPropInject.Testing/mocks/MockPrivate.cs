using Autofac.EasyPropInject.Annotations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Autofac.EasyPropInject.Testing.mocks
{
    public interface IMockPrivate
    {
        IMock1 Mock1Test();
    }

    public class MockPrivate : IMockPrivate
    {
        [FromAutofac]
        private IMock1 mock1 { get; set; }

        public MockPrivate()
        {

        }


        public IMock1 Mock1Test()
        {
            return this.mock1;
        }
    }
}

using Autofac.EasyPropInject.Annotations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Autofac.EasyPropInject.Testing.mocks
{
    public interface IMockProtected
    {
        IMockPrivate GetMockPrivate();
    }

    public class MockProtected : IMockProtected
    {
        [FromAutofac]
        protected IMockPrivate mockPrivate { get; set; }

        public MockProtected()
        {

        }


        public IMockPrivate GetMockPrivate() => this.mockPrivate;



    }
}

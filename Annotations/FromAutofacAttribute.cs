using System;
using System.Collections.Generic;
using System.Text;

namespace Autofac.EasyPropInject.Annotations
{
    [System.AttributeUsage(System.AttributeTargets.Property,
                   AllowMultiple = false,
                   Inherited = true)]
    public class FromAutofacAttribute:Attribute
    {
    }
}

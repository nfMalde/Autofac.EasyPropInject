using System;

namespace Autofac.EasyPropInject.Annotations
{
    /// <summary>
    /// FromAutofac Attribute to mark properties for injection
    /// </summary>
    [System.AttributeUsage(System.AttributeTargets.Property,
                   AllowMultiple = false,
                   Inherited = true)]
    public class FromAutofacAttribute:Attribute
    {
    }
}

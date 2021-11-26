using System;

namespace Autofac.EasyPropInject.Annotations
{
    /// <summary>
    /// FromAutofac Attribute to mark properties for injection
    /// </summary>
    [System.AttributeUsage(System.AttributeTargets.Property,
                   AllowMultiple = false,
                   Inherited = true)]
    public class FromAutofacAttribute : Attribute
    {
        /// <summary>
        /// If set, EasyPropInject will try to load the type out of the autofac container instead of the type that property is decalared
        /// </summary>
        /// <value>
        /// The type of the resolve from registered.
        /// </value>
        public Type ResolveFromRegisteredType { get; set; } = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="FromAutofacAttribute"/> class.
        /// </summary>
        /// <param name="resolveFromRegisteredType">Look up for this type instead of the declared type.</param>
        public FromAutofacAttribute(Type resolveFromRegisteredType = null)
        {
            this.ResolveFromRegisteredType = resolveFromRegisteredType;
        }
    }
}
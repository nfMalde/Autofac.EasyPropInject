using Autofac.Core.Resolving.Pipeline;
using Autofac.EasyPropInject.Annotations;
using System;
using System.Reflection;

namespace Autofac.EasyPropInject.Middleware
{
    /// <summary>
    /// Autofac Resolve Pipeline Middleware for detecting properties decorated with "FromAutofacAttribute"
    /// </summary>
    /// <seealso cref="Autofac.Core.Resolving.Pipeline.IResolveMiddleware" />
    public class EasyPropInjectMiddleware : IResolveMiddleware
    {
        /// <summary>
        /// Gets the phase of the resolve pipeline at which to execute.
        /// </summary>
        public PipelinePhase Phase => PipelinePhase.RegistrationPipelineStart;

        /// <summary>
        /// Invoked when this middleware is executed as part of an active <see cref="T:Autofac.ResolveRequest" />. The middleware should usually call
        /// the <paramref name="next" /> method in order to continue the pipeline, unless the middleware fully satisfies the request.
        /// </summary>
        /// <param name="context">The context for the resolve request.</param>
        /// <param name="next">The method to invoke to continue the pipeline execution; pass this method the <paramref name="context" /> argument.</param>
        public void Execute(ResolveRequestContext context, Action<ResolveRequestContext> next)
        {
            // Call the next middleware in the pipeline.
            next(context);

            // Inject decorated properties
            this._injectEasily(context);
        }

        /// <summary>
        /// Collects all properties of current resolved instance that have the "FromAutofac" Attribute.
        /// </summary>
        /// <param name="context">The context.</param>
        private void _injectEasily(ResolveRequestContext context)
        {
            object instance = context.Instance;

            if (instance != null)
            {
                var props = instance.GetType().GetProperties(BindingFlags.NonPublic | BindingFlags.Instance);

                foreach (PropertyInfo property in props)
                {
                    this._resolve(property, context);
                }
            }
        }

        /// <summary>
        /// Resolves the specified property.
        /// </summary>
        /// <param name="property">The property.</param>
        /// <param name="context">The context.</param>
        private void _resolve(PropertyInfo property, ResolveRequestContext context)
        {
            object instance = context.Instance;

            FromAutofacAttribute attr = property.GetCustomAttribute<FromAutofacAttribute>();

            if (attr != null)
            {
                object propertyInstance = null;
                //Get the correct resolving type
                Type targetType = attr.ResolveFromRegisteredType != null ? attr.ResolveFromRegisteredType : property.PropertyType;
                context.TryResolve(targetType, out propertyInstance);
                // Set value to property with the newly resolved instance
                property.SetValue(instance, propertyInstance);
            }
        }
    }
}
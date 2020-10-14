using Autofac;
using Autofac.Core.Resolving.Middleware;
using Autofac.EasyPropInject.Middleware;
using System;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;

namespace Autofac.EasyPropInject
{
    /// <summary>
    /// Extension class for adding easy prop inject
    /// </summary>
    public static class EasyPropInject
    {
        /// <summary>
        /// Adds the event listeners for auto injecting properties
        /// </summary>
        /// <param name="builder">ContainerBuilder</param>
        /// <returns>ContainerBuilder</returns>
        public static ContainerBuilder AddEasyPropInject(this ContainerBuilder builder)
        {
           
            builder.RegisterCallback(c =>
            {   
                c.Registered += (sender, args) =>
                {
                    // The PipelineBuilding event fires just before the pipeline is built, and
                    // middleware can be added inside it.
                    args.ComponentRegistration.PipelineBuilding += (s, pipeline) =>
                    {
                        // Add EasyPropInjectMiddleware
                        pipeline.Use(new EasyPropInjectMiddleware());
                    };

                };
            });

            return builder;
        }
    }
}

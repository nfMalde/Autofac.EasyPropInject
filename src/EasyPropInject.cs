using Autofac.EasyPropInject.Middleware;

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
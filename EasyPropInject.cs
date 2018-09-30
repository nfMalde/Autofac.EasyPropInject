using System;
using Autofac;
using Autofac.Builder;
using System.Linq;
using System.Reflection;

namespace Autofac.EasyPropInject
{
    public static class EasyPropInject
    {
        public static ContainerBuilder AddEasyPropInject(this ContainerBuilder builder)
        {
            builder.RegisterCallback(c =>
            {
                c.Registered += (sender, args) =>
                {
                    args.ComponentRegistration.Activated += (o, eventArgs) =>
                     {
                         var instance = eventArgs.Instance;
                         if(instance != null)
                         {
                             PropertyInfo[] propertyInfos = instance.GetType().GetProperties();
                             if(propertyInfos.Any(p => p.GetCustomAttribute<Annotations.FromAutofacAttribute>() != null))
                             {
                                 propertyInfos.Where(p => p.GetCustomAttribute<Annotations.FromAutofacAttribute>() != null)
                                 .ToList()
                                 .ForEach(p =>
                                 {

                                     Type propType = p.PropertyType;

                                     object propInstance = null;
                                     if (eventArgs.Context.TryResolve(propType, out propInstance))
                                     {
                                         p.SetValue(instance, propInstance);
                                     }
                                 });
                             }
                         }
                     };
                };
            });

            return builder;
        }
    }
}

using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Reflection;

namespace ExtensionLibrary.DiExt
{
    public static class DiExtension
    {

        //https://anthonygiretti.com/2019/01/31/implement-dynamic-dependency-injection-in-asp-net-core-2-2-example-with-multitenancy-scenario/
        /*        public static void AddScopedDynamic<TInterface>(this IServiceCollection services, IEnumerable<Type> types)
                {
                    services.AddScoped<Func<string, TInterface>>(serviceProvider => tenant =>
                    {
                        var type = types.FilterByInterface<TInterface>()
                                        .Where(x => x.Name.Contains(tenant))
                                        .FirstOrDefault();

                        if (null == type)
                            throw new KeyNotFoundException("No instance found for the given tenant.");

                        return (TInterface)serviceProvider.GetService(type);
                    });
                }*/


        //https://gist.github.com/GetoXs/5caf0d8cfe6faa8a855c3ccef7c5a541
        /// <summary>
        /// Usage: services.AddAllTypes<IGenerator>(new[] { typeof(FileHandler).GetTypeInfo().Assembly }
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="services"></param>
        /// <param name="assemblies"></param>
        /// <param name="additionalRegisterTypesByThemself"></param>
        /// <param name="lifetime"></param>
        public static void LtcRegisterTypesByInterface<T>(this IServiceCollection services, Assembly[] assemblies
            , bool additionalRegisterTypesByThemself = false
            , ServiceLifetime lifetime = ServiceLifetime.Transient
        )
        {
            var typesFromAssemblies = assemblies.SelectMany(a =>
                a.DefinedTypes.Where(x => x.GetInterfaces().Any(i => i == typeof(T))));
            foreach (var type in typesFromAssemblies)
            {
                services.Add(new ServiceDescriptor(typeof(T), type, lifetime));
                if (additionalRegisterTypesByThemself)
                    services.Add(new ServiceDescriptor(type, type, lifetime));
            }
        }

        /// <summary>
        /// Usage: services.AddAllGenericTypes(typeof(IRequest<>), new[] {typeof(DodajPlikHandler).GetTypeInfo().Assembly});
        /// </summary>
        /// <param name="services"></param>
        /// <param name="t"></param>
        /// <param name="assemblies"></param>
        /// <param name="additionalRegisterTypesByThemself"></param>
        /// <param name="lifetime"></param>
        public static void AddAllGenericTypes(this IServiceCollection services, Type t
            , Assembly[] assemblies
            , bool additionalRegisterTypesByThemself = false
            , ServiceLifetime lifetime = ServiceLifetime.Transient
        )
        {
            var genericType = t;
            var typesFromAssemblies = assemblies.SelectMany(a => a.DefinedTypes.Where(x => x.GetInterfaces()
                .Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == genericType)));

            foreach (var type in typesFromAssemblies)
            {
                services.Add(new ServiceDescriptor(t, type, lifetime));
                if (additionalRegisterTypesByThemself)
                    services.Add(new ServiceDescriptor(type, type, lifetime));
            }
        }
    }
}

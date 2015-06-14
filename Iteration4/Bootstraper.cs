using System.Reflection;
using Autofac;

namespace Iteration4
{
    public class Bootstraper
    {
        public static IContainer Initialise()
        {
            var builder = new ContainerBuilder();
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).
                AsImplementedInterfaces();
            builder.RegisterType<DnaFileProcessor>();

            var container = builder.Build();

            return container;
        }
    }
}
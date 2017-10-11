using Autofac;
using Autofac.Core;
using FVG.FiscalAdapter.Domain.Core.Decorators;
using FVG.FiscalAdapter.Domain.Core.Printer;
using FVG.FiscalAdapter.Domain.Core.Validators;
using System;
using System.Linq;

namespace FVG.FiscalAdapter.Domain.Core.Modules
{
    public class CoreModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();

            builder
                .RegisterAssemblyTypes(assemblies)
                .As(type => type.GetInterfaces()
                .Where(iType => iType.IsClosedTypeOf(typeof(IPrintHandler<>)))
                .Select(iType => new KeyedService("printHandler", iType)));

            builder
                .RegisterAssemblyTypes(assemblies)
                .AsClosedTypesOf(typeof(IValidator<>))
                .AsImplementedInterfaces();

            builder.RegisterGenericDecorator(
                typeof(ValidationEntityHandlerDecorator<>),
                typeof(IPrintHandler<>),
                fromKey: "printHandler",
                toKey: "validationHandler");

            builder.RegisterGenericDecorator(
               typeof(LoggerEntityHandlerDecorator<>),
               typeof(IPrintHandler<>),
               fromKey: "validationHandler");
        }
    }
}
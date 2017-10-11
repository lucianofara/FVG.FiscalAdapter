using Autofac;
using Autofac.Core;
using FVG.FiscalAdapter.Domain.Core.Logger;
using System;
using System.Linq;

namespace FVG.FiscalAdapter.Domain.Core.Modules
{
    public class LogModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .Register((c, p) => new FVG.FiscalAdapter.Domain.Core.Logger.NLog(p.TypedAs<Type>()))
                .AsImplementedInterfaces();
        }

        protected override void AttachToComponentRegistration(IComponentRegistry componentRegistry, IComponentRegistration registration)
        {
            registration.Preparing +=
                (sender, args) =>
                {
                    var forType = args.Component.Activator.LimitType;

                    var logParameter = new ResolvedParameter(
                        (p, c) => p.ParameterType == typeof(ILog),
                        (p, c) => c.Resolve<ILog>(TypedParameter.From(forType)));

                    args.Parameters = args.Parameters.Union(new[] { logParameter });
                };
        }
    }
}
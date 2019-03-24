using Autofac;
using Descriptor.Application.Services;
using Descriptor.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Descriptor.API.AutofacModules
{
	public class ApplicationModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterType<EbayService>().As<IEbayService>();
		}
	}
}

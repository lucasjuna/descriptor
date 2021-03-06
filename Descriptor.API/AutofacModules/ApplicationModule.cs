﻿using Autofac;
using Descriptor.API.Service;
using Descriptor.Application;
using Descriptor.Application.BackgroundJobs;
using Descriptor.Application.Services;
using Descriptor.Domain.Repositories;
using Descriptor.Domain.Seedwork;
using Descriptor.Infrastructure.Utils;
using Descriptor.Persistence.DataContext;
using Descriptor.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Options;
using System;

namespace Descriptor.API.AutofacModules
{
	public class ApplicationModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.Register(c =>
			{
				var appSettings = c.Resolve<IOptions<AppSettings>>().Value;
				var optionsBuilder = new DbContextOptionsBuilder<DescriptorContext>();
				optionsBuilder.ConfigureWarnings(x => x.Throw(RelationalEventId.QueryClientEvaluationWarning));
				optionsBuilder.UseSqlServer(appSettings.ConnectionString, sqlOptions =>
				{
					sqlOptions.EnableRetryOnFailure(maxRetryCount: 10, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
					sqlOptions.MigrationsAssembly(typeof(DescriptorContext).Assembly.FullName);
				});
				return optionsBuilder.Options;
			}).SingleInstance();
			builder.RegisterType<DescriptorContext>().InstancePerLifetimeScope().AsSelf().As<IUnitOfWork>();
			builder.RegisterType<SellerRepository>().As<ISellerRepository>();
			builder.RegisterType<ItemRepository>().As<IItemRepository>();
			builder.RegisterType<ProductImageRepository>().As<IProductImageRepository>();
			builder.RegisterType<IdentityService>().As<IIdentityService>();
			builder.RegisterType<ReviewerRepository>().As<IReviewerRepository>();
			builder.RegisterType<HtmlParser>().As<IHtmlParser>();
			builder.RegisterType<LoadItemsJob>().As<ILoadItemsJob>();
		}
	}
}

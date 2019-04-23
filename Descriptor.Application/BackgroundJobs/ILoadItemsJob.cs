﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Descriptor.Application.BackgroundJobs
{
	public interface ILoadItemsJob
	{
		Task Execute(string userName);
	}
}

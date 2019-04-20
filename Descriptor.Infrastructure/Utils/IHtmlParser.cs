using System;
using System.Collections.Generic;
using System.Text;

namespace Descriptor.Infrastructure.Utils
{
	public interface IHtmlParser
	{
		string Parse(string html);
	}
}

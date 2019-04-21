using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace Descriptor.Infrastructure.Utils
{
	public class HtmlParser : IHtmlParser
	{
		public string Parse(string html)
		{
			HtmlDocument doc = new HtmlDocument();
			doc.LoadHtml(html);
			IEnumerable<HtmlNode> nodes = doc.DocumentNode.Descendants().Where(n =>
			   n.NodeType == HtmlNodeType.Text &&
			   n.ParentNode.Name != "script" &&
			   n.ParentNode.Name != "style");
			var sb = new StringBuilder();
			foreach (HtmlNode node in nodes)
			{
				sb.Append(node.InnerText);
			}
			var text = HttpUtility.HtmlDecode(sb.ToString());
			text = Regex.Replace(text, @"[\t ]+", " ");
			text = Regex.Replace(text, @"(\s*(\n|\r|\r\n))+", Environment.NewLine);
			text = text.Trim();
			return text;
		}
	}
}

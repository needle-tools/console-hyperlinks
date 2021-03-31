using System;
using UnityEngine;

namespace Needle
{
	public class OpenURLCallback
	{
		[HyperlinkCallback(Priority = -1)]
		// ReSharper disable once UnusedMember.Local
		private static bool OnHyperlinkClicked(string path, string line)
		{
			if (path.StartsWith("www."))
			{
				Application.OpenURL(path);
				return true;
			}
				
			var result = Uri.TryCreate(path, UriKind.Absolute, out var uriResult) 
			             && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
				
			if (result)
			{
				var url = uriResult.ToString();
				Application.OpenURL(url);
			}

			return result;
		}
	}
}
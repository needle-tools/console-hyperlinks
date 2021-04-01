using System;
using System.Collections.Generic;

namespace Needle
{
	public static class ActionCallback
	{
		public static string Action(this string message, string key, Action act)
		{
			if (!callbacks.ContainsKey(key))
				callbacks.Add(key, act);
			else callbacks[key] = act;
			
			return message.LinkTo(prefix + key);
		}

		private const string prefix = "Action=";
		private static readonly Dictionary<string, Action> callbacks = new Dictionary<string, Action>();
		
		[HyperlinkCallback]
		private static void Callback(string path)
		{
			if (path.StartsWith(prefix))
			{
				var key = path.Substring(prefix.Length);
				if (callbacks.TryGetValue(key, out var act))
				{
					act?.Invoke();
				}
			}
		}
	}
}
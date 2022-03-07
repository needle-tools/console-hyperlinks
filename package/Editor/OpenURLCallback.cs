using System;
using System.Diagnostics;
using System.IO;
using Unity.CodeEditor;
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
				return true;
			}

			
			// if the path is not an url but some external file path open if with default app
			if (File.Exists(path))
			{
                if (int.TryParse(line, out var fileLine) && CodeEditor.CurrentEditor.OpenProject(path, fileLine))
                {
                    return true;
                }

				var absolute = Path.GetFullPath(path);
				var isExternalPath = !absolute.StartsWith(Application.dataPath);
				if (isExternalPath)
				{
					OpenWithDefaultProgram(absolute);
					return true;
				}
			}
			

			return false;
		}
		
		private static void OpenWithDefaultProgram(string path)
		{
			var proc = new Process();
			proc.StartInfo.FileName = "explorer";
			proc.StartInfo.Arguments = "\"" + path + "\"";
			proc.Start();
		}
	}
}
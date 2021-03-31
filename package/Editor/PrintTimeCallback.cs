using System;
using System.Diagnostics;
using UnityEditor;
using Debug = UnityEngine.Debug;

namespace Needle
{
	public class PrintTimeCallback : HyperlinkCallbackReceiver
	{
		public override bool OnHyperlinkClicked(string path, string line)
		{
			if (path != "print_time") return false;
			Debug.Log(DateTime.Now);
			return true;

		}

		[HyperlinkCallback(Priority = 1)]
		public static void OtherCallback(string path, string line)
		{
			Debug.Log("HELLO " + path);
		}
	}
}
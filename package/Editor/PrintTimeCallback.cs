using System;
using UnityEditor;
using UnityEngine;

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
	}
}
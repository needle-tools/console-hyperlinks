using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

namespace Needle
{
	public static class FrameObjects
	{
		private const string framePrefix = "frame=";
		
		public static string Frame(this string message, Transform target)
		{
			return message.LinkTo(framePrefix + target.GetInstanceID());
		}
		
		public static string Frame(this string message, IEnumerable<Transform> targets)
		{
			return message.LinkTo(framePrefix + string.Join(",", targets.Select(t => t.GetInstanceID().ToString())));
		}
		
		[HyperlinkCallback]
		private static void Callback(string path)
		{
			if (!path.StartsWith(framePrefix)) return;
			
			var sub = path.Substring(framePrefix.Length);
			var sep = sub.Split(',');
			var list = new List<Transform>();
			foreach (var str in sep)
			{
				if (int.TryParse(str, out var id))
				{
					var obj = EditorUtility.InstanceIDToObject(id) as Transform;
					if (obj)
					{
						list.Add(obj);
					}
				}
			}

			// ReSharper disable once CoVariantArrayConversion
			Selection.objects = list.Select(t => t.gameObject).ToArray();

			var bounds = new Bounds();
			for (var index = 0; index < list.Count; index++)
			{
				var obj = list[index];
				if (obj.TryGetComponent(out Renderer rend))
				{
					if (bounds.extents == Vector3.zero)
						bounds = rend.bounds;
					else bounds.Encapsulate(rend.bounds);
				}
				else
				{
					var _bounds = new Bounds(obj.position, Vector3.one);
					if (bounds.extents == Vector3.zero)
						bounds = _bounds;
					else bounds.Encapsulate(_bounds);
				}
			}
			SceneView.lastActiveSceneView.Frame(bounds, false);
		}
	}
}
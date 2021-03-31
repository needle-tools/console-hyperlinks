using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

namespace Needle
{
	public static class ZoomToProblem
	{
		public static string Frame(this string message, Transform target)
		{
			return message.LinkTo("target=" + target.GetInstanceID());
		}
		
		[HyperlinkCallback]
		private static void Callback(string path)
		{
			const string key = "target=";
			if (path.StartsWith(key))
			{
				var idstring = path.Substring(key.Length);
				if (int.TryParse(idstring, out var id))
				{
					var obj = EditorUtility.InstanceIDToObject(id) as Transform;
					if (obj)
					{
						if (obj.TryGetComponent(out Renderer rend))
						{
							SceneView.lastActiveSceneView.Frame(rend.bounds, false);
						}
						else
						{
							var bounds = new Bounds(obj.position, Vector3.one);
							SceneView.lastActiveSceneView.Frame(bounds, false);
						}
					}
				}
			}
		}
	}
}
#if UNITY_EDITOR

using UnityEngine;

namespace Needle
{
	public class CallbackReceiverComponent : MonoBehaviour, IHyperlinkCallbackReceiver
	{
		public bool OnHyperlinkClicked(string path, string line)
		{
			Debug.Log(this + "-> " + path, this);
			return false;
		}

		[ContextMenu(nameof(Emit))]
		private void Emit()
		{
			Debug.Log("test".LinkTo("hello_world"));
		}
	}
}
#endif
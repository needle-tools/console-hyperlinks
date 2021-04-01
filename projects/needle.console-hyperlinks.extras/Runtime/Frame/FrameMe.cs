using System.Linq;
using Needle;
using UnityEditor;
using UnityEngine;

[ExecuteInEditMode]
public class FrameMe : MonoBehaviour
{
	private void OnEnable()
	{
		Debug.LogFormat(LogType.Error, LogOption.NoStacktrace, null,
			"Some error message\n" +
			$"Click to zoom to {name}".Frame(transform) + "\n" +
			$"Click to frame all".Frame(FindObjectsOfType<FrameMe>().Select(f => f.transform)) + "\n" +
			$"Click to print another log".Action(GetInstanceID().ToString(), PrintAnotherMessage)
		);
	}

	private void PrintAnotherMessage()
	{
		Debug.Log("Received callback " + this, this);
	}
}
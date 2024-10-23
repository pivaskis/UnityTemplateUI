using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraSize : MonoBehaviour
{
	
	private void Awake()
	{
		var cameraMain = Camera.main;

		Debug.Log(Camera.main.aspect);
		if (cameraMain.aspect < 0.56)
		{
			cameraMain.orthographicSize = 1140;
		}
	}
}
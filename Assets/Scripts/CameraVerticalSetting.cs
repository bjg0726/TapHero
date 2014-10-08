using UnityEngine;
using System.Collections;

public class CameraVerticalSetting : MonoBehaviour {

	public float imageWidth = 720.0f;
	public float imageHeight = 1280.0f;

	void Awake () {
		Camera.main.orthographicSize = (imageWidth * 0.5f) * (Camera.main.pixelHeight / Camera.main.pixelWidth);
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

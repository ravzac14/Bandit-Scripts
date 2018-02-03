namespace camera {
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;

	/* Scale camera size with Screen height */
	public class CameraScaleHeight : MonoBehaviour {

		public float screenRatio = 3.5f;
		Camera targetCamera;

		void Start() {
			targetCamera = GetComponent<Camera>();
		}

		void Update() {
			targetCamera.orthographicSize = (Screen.height / 100f) / screenRatio;
		}
	}
}

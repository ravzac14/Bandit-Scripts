namespace camera {
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;

	public class CameraFollow : MonoBehaviour {

		public Transform target;
		public float moveSpeed = 0.1f;
		public float zoomOut = -10f;
	
		void Update () {
			if (target) {
				Vector3 cameraDefaultZ = new Vector3(0, 0, zoomOut);
				transform.position = Vector3.Lerp(transform.position, target.position, moveSpeed) + cameraDefaultZ;
			}
		}
	}
}

namespace map {
	using ScreenFader = hud.ScreenFader;
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;

	public class Warp : MonoBehaviour {

		public Transform warpTarget;
	
		// OnTrigger set Player/Camera to target
		private IEnumerator OnTriggerEnter2D(Collider2D collision) {
			ScreenFader sf = GameObject.FindGameObjectWithTag("fader").GetComponent<ScreenFader>();

			yield return StartCoroutine(sf.FadeToBlack());

			collision.gameObject.transform.position = warpTarget.position;
			Camera.main.transform.position = warpTarget.position;

			yield return StartCoroutine(sf.FadeToClear());
		}
	}
}

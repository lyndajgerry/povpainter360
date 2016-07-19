using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class VideoPlayer : MonoBehaviour
{

	private bool IsPlaying = false;

	public enum Handedness { Right, Left};

	public Handedness PaintingHand = Handedness.Right;

	public GameObject leftSphere, rightSphere;

	public GameObject StartText;

	public void StartVideo(int hand){


		StartText.SetActive (false);

		if (!IsPlaying) {
			
		if (hand == 0) {
			PaintingHand = Handedness.Left;
		} else {
			PaintingHand = Handedness.Right;
		}



			((MovieTexture)leftSphere.GetComponent<Renderer> ().material.mainTexture).Play ();
			((MovieTexture)rightSphere.GetComponent<Renderer> ().material.mainTexture).Play ();

		}


		IsPlaying = true;

		StartCoroutine(PlayingCheck());
	}

	IEnumerator PlayingCheck(){

		yield return new WaitUntil (() => ((MovieTexture)rightSphere.GetComponent<Renderer> ().material.mainTexture).isPlaying);


		IsPlaying = false;


	}

}
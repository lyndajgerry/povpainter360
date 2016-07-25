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


    void Update()
    {

        if (Input.GetKeyDown(KeyCode.R))
        {
            StartVideo(1);
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            StartVideo(0);
        }

    }

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

        if(PaintingHand == Handedness.Right)
        {

            leftSphere.transform.localScale = new Vector3(10, 10, -10);
            rightSphere.transform.localScale = new Vector3(10, 10, -10);
        }
        else
        {

            leftSphere.transform.localScale = new Vector3(10, 10, 10);
            rightSphere.transform.localScale = new Vector3(10, 10, 10);
        }


        GetComponent<AudioSource>().Play();


		IsPlaying = true;

		StartCoroutine(PlayingCheck());
	}

	IEnumerator PlayingCheck(){

        yield return new WaitForSeconds(((MovieTexture)rightSphere.GetComponent<Renderer>().material.mainTexture).duration);


		IsPlaying = false;


	}

}
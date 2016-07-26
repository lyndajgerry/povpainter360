using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.VR;

public class VideoPlayer : MonoBehaviour
{

	private bool IsPlaying = false;

	public enum Handedness { Right, Left};

	public Handedness PaintingHand = Handedness.Right;

	public GameObject leftSphere, rightSphere;

	public GameObject StartText;

    bool IsPaused = false;

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

        if (Input.GetKeyDown(KeyCode.C))
        {
            InputTracking.Recenter();
        }

        if (Input.GetKeyDown(KeyCode.Space) && IsPlaying)
        {
            if (!IsPaused)
            {
                PauseVideo();
            }
            else
            {
                ResumeVideo();
            }
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


		//StartCoroutine(PlayingCheck());
	}

    void PauseVideo()
    {
        ((MovieTexture)leftSphere.GetComponent<Renderer>().material.mainTexture).Pause();
        ((MovieTexture)rightSphere.GetComponent<Renderer>().material.mainTexture).Pause();
        GetComponent<AudioSource>().Pause();

        IsPaused = true;
    }

    void ResumeVideo()
    {
        ((MovieTexture)leftSphere.GetComponent<Renderer>().material.mainTexture).Play();
        ((MovieTexture)rightSphere.GetComponent<Renderer>().material.mainTexture).Play();
        GetComponent<AudioSource>().UnPause();

        IsPaused = false;
    }

    IEnumerator PlayingCheck(){

        yield return new WaitForSeconds(((MovieTexture)rightSphere.GetComponent<Renderer>().material.mainTexture).duration);


		IsPlaying = false;


	}

}
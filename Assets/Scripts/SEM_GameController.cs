using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.SceneManagement;

public class SEM_GameController : MonoBehaviour {

    public GameObject PlayerOne;
    public GameObject PlayerTwo;

    public static SEM_GameController GameContoller;

    public List<SEM_WaypointCheck> Waypoints;

    public SEM_WaypointCheck FinishLine;

    private AudioSource _ASource;
    public List<AudioClip> Clips; 

    public AudioSource ASource
    {
        get
        {
            if (_ASource == null)
                _ASource = GetComponent<AudioSource>();

            return _ASource;
        }
    }




    void Start()
    {
        if (GameContoller == null)
            GameContoller = this;


    }

	
	// Update is called once per frame
	void Update ()
	{

	    PlayAudio();




	}

    public bool CheckForWinElegibility (GameObject p)
    {


        foreach(SEM_WaypointCheck WP in Waypoints)
        {
            if (!WP.CrossedWaypoint(p))
                return false;
        }

        return true;
    }


    private bool stopSound = true;
    private void PlayAudio()
    {
        float playerOneMoving = Input.GetAxis(SEM_ControllerController.Accelerator(Players.PlayerOne, false)); 
       // Debug.Log(playerOneMoving);

        if (playerOneMoving == 0)
            playerOneMoving = Input.GetAxis(SEM_ControllerController.Accelerator(Players.PlayerOne, true));

        float playerTwoMoving  = Input.GetAxis(SEM_ControllerController.Accelerator(Players.PlayerTwo, false));

        if (playerOneMoving > 0 || playerTwoMoving > 0)
        {

            PlayClip(Clips[0]);
            stopSound = false;
        }

        else if (playerOneMoving < 0 || playerTwoMoving < 0)
        {
            PlayClip(Clips[0]);
            stopSound = false;
        }
        else
        {
            if (stopSound)
                return;

            if (PlayClip(Clips[1]))
                stopSound = true;
        }
    }

    private bool PlayClip(AudioClip audioClip)
    {
        if (ASource.isPlaying)
            return false;
        ASource.clip = audioClip;
        ASource.Play();
        return true;
    }

    internal void Winner(Players p)
    {

        //PlayerOne.GetComponentInChildren<SEM_PlayerUI>().WinLose(p);
        //PlayerTwo.GetComponentInChildren<SEM_PlayerUI>().WinLose(p);
        SEM_WinData.Winner = p;
        StartCoroutine(Reset());

    }

    private IEnumerator Reset()
    {
        yield return new WaitForSeconds(5);
        GameContoller = null;
       
        SceneManager.LoadScene(2);
        //Application.LoadLevel(0);
    }
}

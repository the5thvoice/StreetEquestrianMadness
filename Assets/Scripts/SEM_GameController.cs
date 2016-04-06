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

    private void PlayAudio()
    {
        float playerOneMoving = Input.GetAxis(SEM_ControllerController.Accelerator(Players.PlayerOne, false)); 
       // Debug.Log(playerOneMoving);

        if (playerOneMoving == 0)
            playerOneMoving = Input.GetAxis(SEM_ControllerController.Accelerator(Players.PlayerOne, true));

        float playerTwoMoving = playerOneMoving = Input.GetAxis(SEM_ControllerController.Accelerator(Players.PlayerTwo, false));

        if(playerOneMoving > 0 || playerTwoMoving > 0)
            ASource.Play();
        else if (playerOneMoving < 0 || playerTwoMoving < 0)
            ASource.Play();
        else
        {
            ASource.Stop();
        }
    }

    internal void Winner(Players p)
    {

        PlayerOne.GetComponentInChildren<SEM_PlayerUI>().WinLose(p);
        PlayerTwo.GetComponentInChildren<SEM_PlayerUI>().WinLose(p);
        StartCoroutine(Reset());

    }

    private IEnumerator Reset()
    {
        GameContoller = null;
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(0);
        //Application.LoadLevel(0);
    }
}

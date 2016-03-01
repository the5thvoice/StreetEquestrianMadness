using UnityEngine;
using System.Collections;
using System;

public class SEM_WaypointCheck : MonoBehaviour {

    public float Radius;

    public GameObject PlayerOne
    {
        get
        {
            return SEM_GameController.GameContoller.PlayerOne;
        }
    }

    public GameObject PlayerTwo
    {
        get
        {
            return SEM_GameController.GameContoller.PlayerTwo;
        }
    }

    public bool finsihLine = false;
    public bool PlayerOneCheck = false;
    public bool PlayerTwoCheck = false;


    // Update is called once per frame
    void Update() {

        if (finsihLine)
            CheckWin();
        else
            CheckWaypoint();



    }

    public bool CrossedWaypoint(GameObject p)
    {
        if (p == PlayerOne)
            return PlayerOneCheck;
        if (p == PlayerTwo)
            return PlayerTwoCheck;

        return false;
    }

    private void CheckWin()
    {
        if (Vector3.Distance(PlayerOne.transform.position, transform.position) < Radius)
        {
            if (SEM_GameController.GameContoller.CheckForWinElegibility(PlayerOne))
            {
                PlayerOneCheck = true;
                SEM_GameController.GameContoller.Winner(Players.PlayerOne);
            }
        }

    }

    private void CheckWaypoint()
    {
        if (Vector3.Distance(PlayerOne.transform.position, transform.position) < Radius)
            PlayerOneCheck = true;
        if (Vector3.Distance(PlayerTwo.transform.position, transform.position) < Radius)
            PlayerTwoCheck = true;
    }
}

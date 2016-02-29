using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class SEM_PlayerUI : MonoBehaviour {


    Players PlayerNumber
    {
        get
        {
            return CurrentPlayer.PlayerNumber;
        }
    }


    SEM_CharacterController _CurrentPlayer;
    SEM_CharacterController CurrentPlayer
    {
        get
        {
            if (_CurrentPlayer == null)
                _CurrentPlayer = GetComponentInParent<SEM_CharacterController>();

            return _CurrentPlayer;
        }


    }

    public Text Speed;
    public Text Gear;
    public Text Win_Lose;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        DisplaySpeed();
        DisplayGear();
	
	}

    private void DisplaySpeed()
    {
        Speed.text = "Speed: " + (int)CurrentPlayer.CurrentSpeed;
    }

    private void DisplayGear()
    {
        Gear.text = "Gear: " + CurrentPlayer.Gear;
    }

    public void WinLose(Players p)
    {
        switch (p)
        {
            case Players.PlayerOne:

                return;
            case Players.PlayerTwo:

                return;
        }
    }
}

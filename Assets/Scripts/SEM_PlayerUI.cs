using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.Runtime.CompilerServices;
using System.Security.Policy;

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

    public RectTransform ScaleFace;
    public RectTransform Needle;
    public bool broken = false;
    public float timeToBreak;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        DisplaySpeed();
        DisplayGear();

	    if (!broken)
	        DisplayVisualSpeed();
        if (broken)
            BreakObject();

    }

    private float toBank;
    public float bankAngle;
    private void DisplayVisualSpeed()
    {
        float rotation = 0;
        if (CurrentPlayer.CurrentSpeed > 0)
        {
            rotation = -0.1f;
            timeToBreak -= Time.deltaTime;
        }
        else if (CurrentPlayer.CurrentSpeed < 0)
        {
            rotation = 0.1f;
            timeToBreak -= Time.deltaTime;
        }

        if (timeToBreak <= 0)
        {
            broken = true;
            
            return;
            
        }

        Vector3 needleaAngle = Needle.transform.localEulerAngles;
        toBank = Mathf.Lerp(toBank, rotation, Time.deltaTime);
        needleaAngle.z = -toBank*bankAngle;
        needleaAngle.x = 1;
        Needle.transform.localEulerAngles = needleaAngle;


    }

    private void BreakObject()
    {

        

        if(!ScaleFace.gameObject.activeSelf || !Needle.gameObject.activeSelf)
            return;
        
        ScaleFace.Translate(Vector3.down*Time.deltaTime*5);
        Needle.Translate(Vector3.down*Time.deltaTime*2);

        if (ScaleFace.position.y <= -150)
            ScaleFace.gameObject.SetActive(false);




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

                if (p == PlayerNumber)
                    Win_Lose.text = "Bragging Rights";
                else
                    Win_Lose.text = "you lose";

                return;
            case Players.PlayerTwo:
                if (p == PlayerNumber)
                    Win_Lose.text = "Bragging Rights";
                else
                    Win_Lose.text = "you lose";

                return;
        }
    }
}

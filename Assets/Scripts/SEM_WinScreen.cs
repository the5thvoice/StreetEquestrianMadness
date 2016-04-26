using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SEM_WinScreen : MonoBehaviour
{

    public GameObject PlayerOneWin;
    public GameObject PlayerTwoWin;

	// Use this for initialization
	void Start () {

	    switch (SEM_WinData.Winner)
	    {
            case Players.PlayerOne:
                PlayerOneWin.GetComponent<Image>().enabled = true;

                break;
            case Players.PlayerTwo:
                PlayerTwoWin.GetComponent<Image>().enabled = true;

                break;
	        
	    }
	
	}
	
	
}

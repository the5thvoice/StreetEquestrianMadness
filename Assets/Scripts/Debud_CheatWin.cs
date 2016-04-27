using UnityEngine;
using System.Collections;

public class Debud_CheatWin : MonoBehaviour
{

    public bool DebugMode;

    public void Update()
    {

        if (!DebugMode)
            return;

        float buttonpress = Input.GetAxis("DebugButton");

        float random = Random.Range(0, 2);

        if (buttonpress > 0 && random < 1) 
            SEM_GameController.GameContoller.Winner(Players.PlayerOne);
        else if (buttonpress > 0 && random >= 1)
            SEM_GameController.GameContoller.Winner(Players.PlayerTwo);

    }
}

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

        if (buttonpress > 0)
            SEM_GameController.GameContoller.Winner(Players.PlayerOne);

    }
}

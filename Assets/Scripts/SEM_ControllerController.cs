using UnityEngine;
using System.Collections;

public enum Players
{
    PlayerOne,
    PlayerTwo,
}

public class SEM_ControllerController : MonoBehaviour {

    public static string Horizantal(Players p, bool Keyboard)
    {
        switch (p)
        {
            default:
            case Players.PlayerOne:
                if (!Keyboard)
                    return "PlayerOneHorizontal";
                else
                    return "PlayerOneHorizontalKeyboard";
                
            case Players.PlayerTwo:
                return "PlayerTwoHorizontal";

        }
    }

    public static string Accelerator(Players p, bool Keyboard)
    {
        switch (p)
        {
            default:
            case Players.PlayerOne:
                if (!Keyboard)
                    return "PlayerOneAccelPad";
                else
                    return "PlayerOneAccelKeyboard";
            case Players.PlayerTwo:
                return "PlayerTwoAccel";

        }
    }


    public static string GearShift(Players p)
    {
        switch (p)
        {
            default:
            case Players.PlayerOne:
                
                    return "PlayerOneGearShift";
                
            case Players.PlayerTwo:
                return "PlayerTwoGearShift";

        }
    }


    public static string Quit()
    {
        return "QuitButton";
    }

    public static string Start()
    {
        return "StartButton";
    }
}

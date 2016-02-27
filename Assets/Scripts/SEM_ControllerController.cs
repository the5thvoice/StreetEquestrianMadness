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
                if (Keyboard)
                    return "PlayerOneHorizontalPad";
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
                if (Keyboard)
                    return "PlayerOneAccelPad";
                else
                    return "PlayerOneAccelKeyboard";
            case Players.PlayerTwo:
                return "PlayerTwoAccel";

        }
    }


    public static string GearShift(Players p, bool Keyboard)
    {
        switch (p)
        {
            default:
            case Players.PlayerOne:
                if (Keyboard)
                    return "PlayerOneGearShiftPad";
                else
                    return "PlayerOneGearShiftKeyboard";
            case Players.PlayerTwo:
                return "PlayerTwoGearShift";

        }
    }


}

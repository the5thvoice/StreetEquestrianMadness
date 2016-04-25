using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SEM_StartScreen : MonoBehaviour {

	
	
	// Update is called once per frame
	void Update ()
	{

	    StartGame();
	    QuitGame();

	}

    private void QuitGame()
    {
        float quit = Input.GetAxis(SEM_ControllerController.Quit());

        if (quit > 0)
        {
            //Debug.Log("quit");
            Application.Quit();
        }

    }

    private void StartGame()
    {
        float start = Input.GetAxis(SEM_ControllerController.Start());

        if (start > 0)
            SceneManager.LoadScene(1);
    }
}

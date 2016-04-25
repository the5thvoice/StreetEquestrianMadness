using UnityEngine;
using System.Collections;

public class SEM_ToolTips : MonoBehaviour
{


    public float timer;

    public GameObject ToolTipDisp;

	// Use this for initialization
	void Start ()
	{

	    StartCoroutine(DeactivateToolTip());

	}

    private IEnumerator DeactivateToolTip()
    {
        yield return new WaitForSeconds(timer);

        ToolTipDisp.SetActive( false);

    }

    
}
